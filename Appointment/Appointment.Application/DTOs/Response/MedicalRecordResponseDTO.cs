using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.Application.DTOs.Response
{
    public class MedicalRecordResponseDTO
    {
        public Guid Id { get; private set; }
        public string Diagnosis { get; private set; }
        public string Treatment { get; private set; }
        public string Prescriptions { get; private set; }
        public DateTime? FollowUpDate { get; private set; }
        public DateTime RecordedAt { get; private set; }
        public MedicalRecordResponseDTO(Guid id, string diagnosis, string treatment, string prescriptions, DateTime? followUpDate, DateTime recordedAt)
        {
            Id = id;
            Diagnosis = diagnosis;
            Treatment = treatment;
            Prescriptions = prescriptions;
            FollowUpDate = followUpDate;
            RecordedAt = recordedAt;
        }
    }
}
