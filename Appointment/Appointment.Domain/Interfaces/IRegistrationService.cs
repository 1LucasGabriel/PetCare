using System;
using System.Threading.Tasks;

namespace Appointment.Domain.Interfaces
{
    public interface IRegistrationService
    {
        Task<bool> VerifyPetExistsAsync(Guid petId);
    }
}
