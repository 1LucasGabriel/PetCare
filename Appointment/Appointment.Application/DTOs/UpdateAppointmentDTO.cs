using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.Application.DTOs
{
    public class UpdateAppointmentDTO
    {
        public string Reason { get; set; } = string.Empty;
        public string? Notes { get; set; }
    }
}