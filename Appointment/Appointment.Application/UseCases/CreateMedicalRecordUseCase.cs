using Appointment.Application.DTOs;
using Appointment.Domain.Entities;
using Appointment.Domain.Enums;
using Appointment.Domain.Interfaces.IRepositories;

namespace Appointment.Application.UseCases
{
    public class CreateMedicalRecordUseCase
    {
        private readonly IMedicalRecordRepository _medicalRecordRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public CreateMedicalRecordUseCase(IMedicalRecordRepository medicalRecordRepository, IAppointmentRepository appointmentRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
            _appointmentRepository = appointmentRepository;
        }

        public Guid Run(CreateMedicalRecordDTO request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.AppointmentId == Guid.Empty)
                throw new ArgumentException("O ID da consulta é obrigatório.");

            var appointment = _appointmentRepository.GetById(request.AppointmentId);

            if (appointment == null)
                throw new InvalidOperationException("A consulta informada não foi encontrada.");

            if (appointment.Status != AppointmentStatus.Completed)
                throw new InvalidOperationException("O prontuário médico só pode ser criado para consultas concluídas.");

            var medicalRecord = new MedicalRecord();

            medicalRecord.Create(
                request.AppointmentId,
                request.Diagnosis,
                request.Treatment,
                request.Prescriptions,
                request.FollowUpDate
            );

            _medicalRecordRepository.Create(medicalRecord);

            return medicalRecord.Id;
        }
    }
}