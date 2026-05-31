using Appointment.Application.DTOs.Response;
using Appointment.Domain.Interfaces.IRepositories;

namespace Appointment.Application.UseCases
{
    public class GetAppointmentUseCase
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public GetAppointmentUseCase(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public AppointmentResponseDTO Run(Guid id)
        {
            var a = _appointmentRepository.GetById(id);

            if (a == null)
                throw new Exception("Consulta não encontrada.");

            return new AppointmentResponseDTO(
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
                a.UpdatedAt);
        }
    }
}
