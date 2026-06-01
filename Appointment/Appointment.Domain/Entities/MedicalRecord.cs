using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.Domain.Entities
{
    public class MedicalRecord
    {
        public Guid Id {  get; private set; }
        public Guid AppointmentId { get; private set; }
        public string Diagnosis { get; private set; }
        public string? Treatment { get; private set; }
        public List<string>? PrescribedMedications { get; private set; }
        public DateTime? FollowUpDate { get; private set; }
        public DateTime RecordedAt { get; private set; }

        public ICollection<AppointmentEntity> Appointments { get; private set; } = new List<AppointmentEntity>();
        public void Create(Guid appointmentId, string diagnosis, string? treatment, List<string>? prescriptions, DateTime? followUpDate)
        {
            Id = Guid.NewGuid();
            AppointmentId = appointmentId;
            Diagnosis = diagnosis;
            Treatment = treatment;
            PrescribedMedications = prescriptions;
            FollowUpDate = followUpDate;
            RecordedAt = DateTime.UtcNow;
            VerifyDiagnosis();
            FollowUpDateBiggerThanRecordedAt();
        }

        public void Update(string diagnosis, string? treatment, List<string>? prescriptions, DateTime? followUpDate)
        {
            Diagnosis = diagnosis;
            Treatment = treatment;
            PrescribedMedications = prescriptions;
            FollowUpDate = followUpDate;
            VerifyDiagnosis();
            FollowUpDateBiggerThanRecordedAt();
        }

        public void VerifyDiagnosis()
        {
            if (string.IsNullOrWhiteSpace(Diagnosis))
            {
                throw new ArgumentException("Diagnostico não pode estar vazio.");
            }
        }

        public void FollowUpDateBiggerThanRecordedAt()
        {
            if (FollowUpDate.HasValue && FollowUpDate.Value <= RecordedAt)
            {
                throw new ArgumentException("Data de acompanhamento deve ser posterior à data de registro.");
            }
        }
    }
}
