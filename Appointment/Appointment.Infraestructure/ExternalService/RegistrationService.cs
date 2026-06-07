using Appointment.Domain.Interfaces;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Appointment.Infrastructure.ExternalService
{
    public class RegistrationService : IRegistrationService
    {
        private readonly HttpClient _httpClient;

        public RegistrationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> VerifyPetExistsAsync(Guid petId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/GetPet/{petId}");

                if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
