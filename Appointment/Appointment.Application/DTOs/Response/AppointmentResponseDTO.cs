using Appointment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.Application.DTOs.Response
{
    public class AppointmentResponseDTO
    {
        public Guid Id { get; set; }
        public Guid PetId { get; set; }
        public Guid OwnerId { get; set; }
        public Guid VeterinarianId { get; set; }
        public DateTime ScheduledStart { get; set; }
        public DateTime ScheduledEnd { get; set; }
        public AppointmentStatus Status { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string? Notes { get; set; }
        public string? CancelReason { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public AppointmentResponseDTO(Guid id, Guid petId, Guid ownerId, Guid veterinarianId, DateTime scheduledStart, DateTime scheduledEnd, AppointmentStatus status, string reason, string? notes, string? cancelReason, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            PetId = petId;
            OwnerId = ownerId;
            VeterinarianId = veterinarianId;
            ScheduledStart = scheduledStart;
            ScheduledEnd = scheduledEnd;
            Status = status;
            Reason = reason;
            Notes = notes;
            CancelReason = cancelReason;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
