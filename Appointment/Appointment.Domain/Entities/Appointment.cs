using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.Domain.Entities
{
    public class Appointments
    {
        public Guid Id { get; private set; }
        public Guid PetId { get; private set; }
        public Guid OwnerId { get; private set; }
        public Guid VeterinarianId {  get; private set; }
        public DateTime ScheduleStart { get; private set; }
        public DateTime ScheduleEnd { get; private set; }
        public Enum Status { get; private set; }
        public string Reason { get; private set; }
        public string? Notes { get; private set; }
        public string? CancelReason { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public Appointments(Guid petId, Guid ownerId, Guid veterinarianId, DateTime scheduleStart, DateTime scheduleEnd, Enum status, string reason, string? notes = null, string? cancelReason = null)
        {
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
            ScheduleEndBiggerThanScheduleStart();
            ScheduleStartBiggerThanNow();
        }

        public void Update(DateTime scheduleStart, DateTime scheduleEnd, Enum status, string reason, string? notes = null, string? cancelReason = null)
        {
            ScheduleStart = scheduleStart;
            ScheduleEnd = scheduleEnd;
            Status = status;
            Reason = reason;
            Notes = notes;
            CancelReason = cancelReason;
            UpdatedAt = DateTime.UtcNow;
            ScheduleEndBiggerThanScheduleStart();
            ScheduleStartBiggerThanNow();
        }

        public void ScheduleEndBiggerThanScheduleStart()
        {
            if (ScheduleEnd <= ScheduleStart)
            {
                throw new ArgumentException("Data de término deve ser posterior à data de início.");
            }
        }

        public void ScheduleStartBiggerThanNow()
        {
            if (ScheduleStart <= DateTime.UtcNow)
            {
                throw new ArgumentException("Data de início deve ser futura.");
            }
        }

    }
}
