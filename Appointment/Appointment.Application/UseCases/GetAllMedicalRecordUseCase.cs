using Appointment.Application.DTOs.Response; // Assumindo o namespace do seu DTO
using Appointment.Domain.Entities;
using Appointment.Domain.Interfaces.IRepositories;
using System.Collections.Generic;

namespace Appointment.Application.UseCases
{
    public class GetAllMedicalRecordsUseCase
    {
        private readonly IMedicalRecordRepository _medicalRecordRepository;

        public GetAllMedicalRecordsUseCase(IMedicalRecordRepository medicalRecordRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
        }

        public List<MedicalRecordResponseDTO> Run()
        {

            return _medicalRecordRepository.GetAll().ConvertAll(record => new MedicalRecordResponseDTO(
                record.Id,
                record.Diagnosis,
                record.Treatment,
                record.Prescriptions,
                record.AppointmentId,
                record.FollowUpDate,
                record.RecordedAt
            ));
        }
    }
}