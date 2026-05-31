using Appointment.Domain.Interfaces.IRepositories;

namespace Appointment.Application.UseCases
{
    public class DeleteAppointmentUseCase
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public DeleteAppointmentUseCase(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public void Run(Guid id)
        {
            var appointment = _appointmentRepository.GetById(id);

            if (appointment == null)
                throw new Exception("Consulta não encontrada.");

            _appointmentRepository.Delete(id);
        }
    }
}
