using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.Application.DTOs
{
    public class CreateAppointmentDTO
    {
        public Guid PetId { get; set; }
        public Guid OwnerId { get; set; }
        public Guid VeterinarianId { get; set; }
        public DateTime ScheduledStart { get; set; }
        public DateTime ScheduledEnd { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string? Notes { get; set; }
    }
}
