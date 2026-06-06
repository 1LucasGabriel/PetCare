using Registration.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Infrastructure.ExternalService
{
    public class AppointmentService : IAppointmentService
    {
        private readonly HttpClient _httpClient;

        public AppointmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> HasFutureAppointmentsAsync(Guid petId)
        {
            var response = await _httpClient.GetAsync($"/CheckFutureAppointments/{petId}");
            return response.IsSuccessStatusCode;
        }
    }
}
