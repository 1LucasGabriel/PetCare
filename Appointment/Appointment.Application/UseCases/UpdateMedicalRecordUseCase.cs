using Appointment.Application.DTOs;
using Appointment.Domain.Entities;
using Appointment.Domain.Interfaces.IRepositories;
using System;

namespace Appointment.Application.UseCases
{
    public class UpdateMedicalRecordUseCase
    {
        private readonly IMedicalRecordRepository _medicalRecordRepository;

        public UpdateMedicalRecordUseCase(IMedicalRecordRepository medicalRecordRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
        }

        public void Run(UpdateMedicalRecordDTO request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.Id == Guid.Empty)
                throw new ArgumentException("O ID do prontuário é obrigatório para a atualização.");

            var medicalRecord = _medicalRecordRepository.GetById(request.Id);

            if (medicalRecord == null)
                throw new InvalidOperationException("O prontuário médico informado não foi encontrado.");

            medicalRecord.Update(
                request.Diagnosis,
                request.Treatment,
                request.Prescriptions,
                request.FollowUpDate
            );

            _medicalRecordRepository.Update(medicalRecord);
        }
    }
}