using MedicalRecord.Application.DTOs;

namespace MedicalRecord.Application.Ports;

public interface ICreateMedicalRecordUseCase
{
    Task<MedicalRecordResponse> ExecuteAsync(
        CreateMedicalRecordRequest request,
        CancellationToken ct = default);
}