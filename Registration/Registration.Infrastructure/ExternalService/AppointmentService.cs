using Registration.Domain.Interfaces.IRepositories;
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
            var response = await _httpClient.GetAsync($"/appointments/future-check/{petId}");
            return response.IsSuccessStatusCode;
        }
    }
}
