namespace MedicalRecord.Domain.Exceptions;

public abstract class MedicalRecordDomainException : Exception
{
    protected MedicalRecordDomainException(string message) : base(message) { }
}

// Consulta não está "COMPLETED"
public sealed class AppointmentNotCompletedException : MedicalRecordDomainException
{
    public Guid AppointmentId { get; }
    public AppointmentNotCompletedException(Guid id)
        : base($"Prontuário não pode ser criado: consulta '{id}' não está concluída.")
        => AppointmentId = id;
}

// Já existe prontuário para esta consulta
public sealed class DuplicateMedicalRecordException : MedicalRecordDomainException
{
    public Guid AppointmentId { get; }
    public DuplicateMedicalRecordException(Guid id)
        : base($"Já existe um prontuário para a consulta '{id}'.")
        => AppointmentId = id;
}

// Diagnóstico vazio
public sealed class InvalidDiagnosisException : MedicalRecordDomainException
{
    public InvalidDiagnosisException(string message) : base(message) { }
}

// follow_up_date não é futura
public sealed class InvalidFollowUpDateException : MedicalRecordDomainException
{
    public DateOnly FollowUpDate { get; }
    public DateTime RecordedAt { get; }
    public InvalidFollowUpDateException(DateOnly f, DateTime r)
        : base($"Data de retorno '{f}' deve ser posterior a '{DateOnly.FromDateTime(r)}'.")
    { FollowUpDate = f; RecordedAt = r; }
}

// Consulta não encontrada
public sealed class AppointmentNotFoundException : MedicalRecordDomainException
{
    public Guid AppointmentId { get; }
    public AppointmentNotFoundException(Guid id)
        : base($"Consulta '{id}' não encontrada.")
        => AppointmentId = id;
}