using Appointment.Application.DTOs.Response;
using Appointment.Domain.Interfaces.IRepositories;
using System;

namespace Appointment.Application.UseCases
{
    public class GetMedicalRecordUseCase
    {
        private readonly IMedicalRecordRepository _medicalRecordRepository;

        public GetMedicalRecordUseCase(IMedicalRecordRepository medicalRecordRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
        }

        public MedicalRecordResponseDTO Run(Guid id)
        {
            var medicalRecord = _medicalRecordRepository.GetById(id);

            if (medicalRecord == null)
            {
                throw new Exception("Prontuário médico não encontrado.");
            }

            return new MedicalRecordResponseDTO(
                medicalRecord.Id,
                medicalRecord.Diagnosis,
                medicalRecord.Treatment,
                medicalRecord.Prescriptions,
                medicalRecord.AppointmentId,
                medicalRecord.FollowUpDate,
                medicalRecord.RecordedAt
            );
        }
    }
}