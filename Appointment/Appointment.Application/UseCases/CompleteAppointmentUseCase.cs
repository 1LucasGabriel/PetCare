using Appointment.Domain.Enums;
using Appointment.Domain.Interfaces.IRepositories;

namespace Appointment.Application.UseCases
{
    public class CompleteAppointmentUseCase
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public CompleteAppointmentUseCase(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public void Run(Guid id)
        {
            var appointment = _appointmentRepository.GetById(id);

            if (appointment == null)
                throw new Exception("Consulta não encontrada.");

            if (appointment.Status != AppointmentStatus.InProgress)
                throw new InvalidOperationException($"Não é possível concluir uma consulta com status '{appointment.Status}'. Apenas consultas IN_PROGRESS podem ser concluídas.");

            appointment.Update(
                appointment.ScheduleStart,
                appointment.ScheduleEnd,
                AppointmentStatus.Completed,
                appointment.Reason,
                appointment.Notes,
                appointment.CancelReason);

            _appointmentRepository.Update(appointment);
        }
    }
}
