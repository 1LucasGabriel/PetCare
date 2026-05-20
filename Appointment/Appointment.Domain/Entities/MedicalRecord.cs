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
        public List<string>? Prescriptions { get; private set; }
        public DateTime? FollowUpDate { get; private set; }
        public DateTime RecordedAt { get; private set; }

        //public ICollection<Appointment> Appointments { get; private set; } = new List<Appointment>();

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
