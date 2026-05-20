using MedicalRecord.Domain.Enums;

namespace MedicalRecord.Domain.Repositories;

public interface IAppointmentRepository
{
    Task<AppointmentStatus?> GetStatusAsync(Guid appointmentId, CancellationToken ct = default);
}