using Appointment.Application.DTOs;
using Appointment.Domain.Entities;
using Appointment.Domain.Enums;
using Appointment.Domain.Interfaces.IRepositories;

namespace Appointment.Application.UseCases
{
    public class CreateAppointmentUseCase
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IVeterinarianRepository _veterinarianRepository;

        public CreateAppointmentUseCase(IAppointmentRepository appointmentRepository, IVeterinarianRepository veterinarianRepository)
        {
            _appointmentRepository = appointmentRepository;
            _veterinarianRepository = veterinarianRepository;
        }

        public Guid Run(CreateAppointmentDTO request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var veterinarian = _veterinarianRepository.GetById(request.VeterinarianId);
            if (veterinarian == null)
                throw new ArgumentException("Veterinário não encontrado.");

            var vetAppointments = _appointmentRepository.GetByVeterinarianId(request.VeterinarianId);
            var petAppointments = _appointmentRepository.GetByPetId(request.PetId);

            bool vetConflict = vetAppointments.Any(a =>
                a.Status != AppointmentStatus.Cancelled &&
                a.Status != AppointmentStatus.NoShow &&
                a.ScheduleStart < request.ScheduledEnd &&
                a.ScheduleEnd > request.ScheduledStart);

            if (vetConflict)
                throw new InvalidOperationException("O veterinário já possui uma consulta neste horário.");

            bool petConflict = petAppointments.Any(a =>
                a.Status != AppointmentStatus.Cancelled &&
                a.Status != AppointmentStatus.NoShow &&
                a.ScheduleStart < request.ScheduledEnd &&
                a.ScheduleEnd > request.ScheduledStart);

            if (petConflict)
                throw new InvalidOperationException("O pet já possui uma consulta neste horário.");

            var appointment = new Appointments(
                request.PetId,
                request.OwnerId,
                request.VeterinarianId,
                request.ScheduledStart,
                request.ScheduledEnd,
                AppointmentStatus.Scheduled,
                request.Reason,
                request.Notes);

            return _appointmentRepository.Create(appointment);
        }
    }
}
