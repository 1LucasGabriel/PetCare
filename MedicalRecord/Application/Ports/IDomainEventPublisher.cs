using MedicalRecord.Domain.Events;

namespace MedicalRecord.Application.Ports;

public interface IDomainEventPublisher
{
    Task PublishAsync(IDomainEvent domainEvent, CancellationToken ct = default);
}