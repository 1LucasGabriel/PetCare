using Appointment.Application.DTOs;
using Appointment.Domain.Enums;
using Appointment.Domain.Interfaces.IRepositories;

namespace Appointment.Application.UseCases
{
    public class CancelAppointmentUseCase
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public CancelAppointmentUseCase(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public void Run(Guid id, CancelAppointmentDTO request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var appointment = _appointmentRepository.GetById(id);

            if (appointment == null)
                throw new Exception("Consulta não encontrada.");

            if (appointment.Status != AppointmentStatus.Scheduled)
            {
                string statusFriendly = appointment.Status switch
                {
                    AppointmentStatus.Scheduled => "Pendente",
                    AppointmentStatus.InProgress => "Em Andamento",
                    AppointmentStatus.Completed => "Concluída",
                    AppointmentStatus.Cancelled => "Cancelada",
                    _ => appointment.Status.ToString()
                };
                throw new InvalidOperationException($"Não é possível cancelar a consulta porque seu status atual é '{statusFriendly}'. Apenas consultas 'Pendente' podem ser canceladas.");
            }

            if (string.IsNullOrWhiteSpace(request.CancelReason))
                throw new ArgumentException("Motivo do cancelamento é obrigatório.");

            appointment.Update(
                appointment.ScheduleStart,
                appointment.ScheduleEnd,
                AppointmentStatus.Cancelled,
                appointment.Reason,
                appointment.Notes,
                request.CancelReason);

            _appointmentRepository.Update(appointment);
        }
    }
}
