using Appointment.Domain.Enums;
using Appointment.Domain.Interfaces.IRepositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment.Application.UseCases
{
    public class CheckFutureAppointmentsUseCase
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public CheckFutureAppointmentsUseCase(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<bool> ExecuteAsync(Guid petId)
        {
            var appointments = _appointmentRepository.GetByPetId(petId);

            var hasFuture = appointments.Any(a => 
                (a.Status == AppointmentStatus.Scheduled || a.Status == AppointmentStatus.InProgress) 
                && a.ScheduleStart >= DateTime.UtcNow);

            return await Task.FromResult(hasFuture);
        }
    }
}
