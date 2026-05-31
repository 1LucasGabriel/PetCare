using Appointment.Application.DTOs.Response;
using Appointment.Domain.Interfaces.IRepositories;

namespace Appointment.Application.UseCases
{
    public class GetAllAppointmentsUseCase
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public GetAllAppointmentsUseCase(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public List<AppointmentResponseDTO> Run()
        {
            return _appointmentRepository.GetAll().ConvertAll(a => new AppointmentResponseDTO(
                a.Id,
                a.PetId,
                a.OwnerId,
                a.VeterinarianId,
                a.ScheduleStart,
                a.ScheduleEnd,
                a.Status,
                a.Reason,
                a.Notes,
                a.CancelReason,
                a.CreatedAt,
                a.UpdatedAt));
        }
    }
}
