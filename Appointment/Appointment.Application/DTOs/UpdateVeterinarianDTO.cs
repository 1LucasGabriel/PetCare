using System.Collections.Generic;

namespace Appointment.Application.DTOs
{
    public class UpdateVeterinarianDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public List<string>? Specialties { get; set; }
    }
}
