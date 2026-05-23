using MedicalRecord.Application.DTOs;
using MedicalRecord.Application.Ports;
using MedicalRecord.Domain.Exceptions;
using MedicalRecord.Domain.Repositories;

namespace MedicalRecord.Application.UseCases.CreateMedicalRecord;

public sealed class CreateMedicalRecordUseCase : ICreateMedicalRecordUseCase
{
    private readonly IMedicalRecordRepository _medicalRecordRepository;
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDomainEventPublisher _eventPublisher;

    public CreateMedicalRecordUseCase(
        IMedicalRecordRepository medicalRecordRepository,
        IAppointmentRepository appointmentRepository,
        IUnitOfWork unitOfWork,
        IDomainEventPublisher eventPublisher)
    {
        _medicalRecordRepository = medicalRecordRepository;
        _appointmentRepository = appointmentRepository;
        _unitOfWork = unitOfWork;
        _eventPublisher = eventPublisher;
    }

    public async Task<MedicalRecordResponse> ExecuteAsync(
        CreateMedicalRecordRequest request,
        CancellationToken ct = default)
    {
        // 1. Verificar existência e status da consulta
        var appointmentStatus = await _appointmentRepository
            .GetStatusAsync(request.AppointmentId, ct);

        if (appointmentStatus is null)
            throw new AppointmentNotFoundException(request.AppointmentId);

        // 2. Verificar duplicidade
        var alreadyExists = await _medicalRecordRepository
            .ExistsByAppointmentIdAsync(request.AppointmentId, ct);

        // 3. Criar aggregate root — regras de negócio no domínio
        var record = Domain.Entities.MedicalRecord.Create(
            appointmentId: request.AppointmentId,
            appointmentStatus: appointmentStatus.Value,
            alreadyExists: alreadyExists,
            diagnosis: request.Diagnosis,
            treatment: request.Treatment,
            prescribedMedications: request.PrescribedMedications,
            followUpDate: request.FollowUpDate,
            recordedAt: DateTime.UtcNow
        );

        // 4. Persistência (ainda não implementei)
        await _medicalRecordRepository.AddAsync(record, ct);
        await _unitOfWork.CommitAsync(ct);

        // 5. Publicar eventos de domínio
        foreach (var domainEvent in record.DomainEvents)
            await _eventPublisher.PublishAsync(domainEvent, ct);

        record.ClearDomainEvents();

        return new MedicalRecordResponse(
            Id: record.Id,
            AppointmentId: record.AppointmentId,
            Diagnosis: record.Diagnosis,
            Treatment: record.Treatment,
            PrescribedMedications: record.PrescribedMedications,
            FollowUpDate: record.FollowUpDate,
            RecordedAt: record.RecordedAt
        );
    }
}