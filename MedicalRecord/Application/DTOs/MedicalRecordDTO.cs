namespace MedicalRecord.Application.DTOs;

public sealed record CreateMedicalRecordRequest(
    Guid AppointmentId,
    string Diagnosis,
    string? Treatment,
    IReadOnlyList<string>? PrescribedMedications,
    DateOnly? FollowUpDate
);

public sealed record MedicalRecordResponse(
    Guid Id,
    Guid AppointmentId,
    string Diagnosis,
    string? Treatment,
    IReadOnlyList<string> PrescribedMedications,
    DateOnly? FollowUpDate,
    DateTime RecordedAt
);