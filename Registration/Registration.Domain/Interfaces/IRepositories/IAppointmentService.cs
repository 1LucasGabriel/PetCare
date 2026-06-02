using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Domain.Interfaces.IRepositories
{
    public interface IAppointmentService
    {
        Task<bool> HasFutureAppointmentsAsync(Guid petId);
    }
}
