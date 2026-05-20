namespace MedicalRecord.Domain.Events;

public interface IDomainEvent
{
    Guid EventId { get; }
    DateTime OccurredAt { get; }
}

public sealed record MedicalRecordCreatedEvent(
    Guid MedicalRecordId,
    Guid AppointmentId,
    DateTime RecordedAt) : IDomainEvent
{
    public Guid EventId { get; } = Guid.NewGuid();
    public DateTime OccurredAt { get; } = DateTime.UtcNow;
}