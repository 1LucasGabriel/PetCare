namespace MedicalRecord.Domain.Repositories;

public interface IMedicalRecordRepository
{
    Task AddAsync(Entities.MedicalRecord record, CancellationToken ct = default);
    Task<Entities.MedicalRecord?> FindByAppointmentIdAsync(Guid appointmentId, CancellationToken ct = default);
    Task<Entities.MedicalRecord?> FindByIdAsync(Guid id, CancellationToken ct = default);
    Task<bool> ExistsByAppointmentIdAsync(Guid appointmentId, CancellationToken ct = default);
}