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
            {
                string statusFriendly = appointment.Status switch
                {
                    AppointmentStatus.Scheduled => "Pendente",
                    AppointmentStatus.InProgress => "Em Andamento",
                    AppointmentStatus.Completed => "Concluída",
                    AppointmentStatus.Cancelled => "Cancelada",
                    _ => appointment.Status.ToString()
                };
                throw new InvalidOperationException($"Não é possível concluir a consulta porque seu status atual é '{statusFriendly}'. Apenas consultas 'Em Andamento' podem ser concluídas.");
            }

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
