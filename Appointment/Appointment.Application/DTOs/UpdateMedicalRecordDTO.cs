using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.Application.DTOs
{
    public class UpdateMedicalRecordDTO
    {
        public string Prescription { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public DateTime FollowUpDate { get; set; }
    }
}
