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
        public List<string> Prescriptions { get; private set; }
        public Guid AppointmentId { get; private set; }
        public DateTime? FollowUpDate { get; private set; }
        public DateTime RecordedAt { get; private set; }
        public MedicalRecordResponseDTO(Guid id, string diagnosis, string treatment, List<string> prescriptions, Guid appointmentId, DateTime? followUpDate, DateTime recordedAt)
        {
            Id = id;
            Diagnosis = diagnosis;
            Treatment = treatment;
            Prescriptions = prescriptions;
            AppointmentId = appointmentId;
            FollowUpDate = followUpDate;
            RecordedAt = recordedAt;
        }
    }
}
