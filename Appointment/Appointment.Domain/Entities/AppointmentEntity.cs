using Appointment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.Domain.Entities
{
    public class AppointmentEntity
    {
        public Guid Id { get; private set; }
        public Guid PetId { get; private set; }
        public Guid OwnerId { get; private set; }
        public Guid VeterinarianId { get; private set; }
        public DateTime ScheduleStart { get; private set; }
        public DateTime ScheduleEnd { get; private set; }
        public AppointmentStatus Status { get; private set; }
        public string Reason { get; private set; }
        public string? Notes { get; private set; }
        public string? CancelReason { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public Veterinarian? Veterinarian { get; private set; }
        public MedicalRecord? MedicalRecord { get; private set; }

        public AppointmentEntity(Guid petId, Guid ownerId, Guid veterinarianId, DateTime scheduleStart, DateTime scheduleEnd, AppointmentStatus status, string reason, string? notes = null, string? cancelReason = null)
        {

            if (scheduleEnd <= scheduleStart)
            {
                throw new ArgumentException("Data de término deve ser posterior à data de início.");
            }

            if (scheduleStart == scheduleEnd)
            {
                throw new ArgumentException("Data de início e término devem ser diferentes.");
            }

            if (scheduleStart <= DateTime.UtcNow)
            {
                throw new ArgumentException("Data de início deve ser futura.");
            }

            Id = Guid.NewGuid();
            PetId = petId;
            OwnerId = ownerId;
            VeterinarianId = veterinarianId;
            ScheduleStart = scheduleStart;
            ScheduleEnd = scheduleEnd;
            Status = status;
            Reason = reason;
            Notes = notes;
            CancelReason = cancelReason;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Update(DateTime scheduleStart, DateTime scheduleEnd, AppointmentStatus status, string reason, string? notes = null, string? cancelReason = null)
        {
            ScheduleStart = scheduleStart;
            ScheduleEnd = scheduleEnd;
            Status = status;
            Reason = reason;
            Notes = notes;
            CancelReason = cancelReason;
            UpdatedAt = DateTime.UtcNow;
        }

        public AppointmentEntity() { }
    }
}
