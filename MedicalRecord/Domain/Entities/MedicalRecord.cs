using MedicalRecord.Domain.Enums;
using MedicalRecord.Domain.Events;
using MedicalRecord.Domain.Exceptions;

namespace MedicalRecord.Domain.Entities;

// Prontuário Clínico
// Table: appt_medical_records
public sealed class MedicalRecord
{
    public Guid Id { get; private set; }
    public Guid AppointmentId { get; private set; }
    public string Diagnosis { get; private set; }
    public string? Treatment { get; private set; }
    public IReadOnlyList<string> PrescribedMedications { get; private set; }
    public DateOnly? FollowUpDate { get; private set; }
    public DateTime RecordedAt { get; private set; }

    private readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    private MedicalRecord() { }

    public static MedicalRecord Create(
        Guid appointmentId,
        AppointmentStatus appointmentStatus,
        bool alreadyExists,
        string diagnosis,
        string? treatment,
        IEnumerable<string>? prescribedMedications,
        DateOnly? followUpDate,
        DateTime recordedAt)
    {
        // Consulta deve estar CONCLUÍDA
        if (appointmentStatus != AppointmentStatus.Completed)
            throw new AppointmentNotCompletedException(appointmentId);

        // Apenas um prontuário por consulta
        if (alreadyExists)
            throw new DuplicateMedicalRecordException(appointmentId);

        // Diagnóstico obrigatório
        if (string.IsNullOrWhiteSpace(diagnosis))
            throw new InvalidDiagnosisException("O diagnóstico é obrigatório e não pode ser vazio.");

        var medications = (prescribedMedications ?? Enumerable.Empty<string>())
            .Where(m => !string.IsNullOrWhiteSpace(m))
            .ToList();

        // follow_up_date deve ser futura em relação a recorded_at
        if (followUpDate.HasValue &&
            followUpDate.Value <= DateOnly.FromDateTime(recordedAt))
            throw new InvalidFollowUpDateException(followUpDate.Value, recordedAt);

        var record = new MedicalRecord
        {
            Id = Guid.NewGuid(),
            AppointmentId = appointmentId,
            Diagnosis = diagnosis.Trim(),
            Treatment = treatment?.Trim(),
            PrescribedMedications = medications.AsReadOnly(),
            FollowUpDate = followUpDate,
            RecordedAt = recordedAt
        };

        record._domainEvents.Add(
            new MedicalRecordCreatedEvent(record.Id, appointmentId, recordedAt));

        return record;
    }

    public void ClearDomainEvents() => _domainEvents.Clear();
}