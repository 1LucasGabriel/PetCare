using Appointment.Application.DTOs.Response;
using Appointment.Domain.Entities;
using Appointment.Domain.Interfaces.IRepositories;

namespace Appointment.Application.UseCases
{
    public class GetAllMedicalRecordUseCase
    {
        private readonly IMedicalRecordRepository _medicalRecordRepository;

        public GetAllMedicalRecordUseCase(IMedicalRecordRepository medicalRecordRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
        }

        public List<MedicalRecordResponseDTO> Run()
        {

            return _medicalRecordRepository.GetAll().ConvertAll(record => new MedicalRecordResponseDTO(
                record.Id,
                record.Diagnosis,
                record.Treatment,
                record.PrescribedMedications,
                record.AppointmentId,
                record.FollowUpDate,
                record.RecordedAt
            ));
        }
    }
}