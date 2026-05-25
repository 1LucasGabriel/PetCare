using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.Application.DTOs
{
    public class CreateMedicalRecordDTO
    {
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public string Prescriptions { get; set; }
        public DateTime? FollowUpDate { get; set; }
        public DateTime? RecordedAt { get; set; }
    }
}
