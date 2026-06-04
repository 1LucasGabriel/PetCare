using System.Collections.Generic;

namespace Appointment.Application.DTOs
{
    public class CreateVeterinarianDTO
    {
        public string FullName { get; set; }
        public string Crmv { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<string>? Specialties { get; set; }
    }
}
