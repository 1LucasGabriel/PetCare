using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.Application.DTOs
{
    public class UpdateMedicalRecordDTO
    {
        public Guid Id { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public List<string> Prescriptions { get; set; }
        public Guid AppointmentId { get; set; }
        public DateTime FollowUpDate { get; set; }
    }
}
