using Appointment.Domain.Interfaces.IRepositories;
using System;

namespace Appointment.Application.UseCases
{
    public class DeleteMedicalRecordUseCase
    {
        private readonly IMedicalRecordRepository _medicalRecordRepository;

        public DeleteMedicalRecordUseCase(IMedicalRecordRepository medicalRecordRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
        }

        public bool Run(Guid id)
        {
            var medicalRecord = _medicalRecordRepository.GetById(id);

            if (medicalRecord == null)
            {
                throw new Exception("Prontuario medico não encontrado.");
            }

            _medicalRecordRepository.Delete(id);
            return true;
        }
    }
}