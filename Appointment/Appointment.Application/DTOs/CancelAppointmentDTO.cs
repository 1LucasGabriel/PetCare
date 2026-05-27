using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.Application.DTOs
{
    public class CancelAppointmentDTO
    {
        public string CancellationReason { get; set; } = string.Empty;
    }
}
