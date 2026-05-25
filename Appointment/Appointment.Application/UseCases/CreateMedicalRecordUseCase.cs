using Appointment.Application.DTOs;
using Appointment.Domain.Entities;
using Appointment.Domain.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.Application.UseCases
{
    public class CreateMedicalRecordUseCase
    {
        private readonly IMedicalRecordRepository _medicalRecordRepository;

        public CreateMedicalRecordUseCase(IMedicalRecordRepository medicalRecordRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
        }

        //public Guid Run(CreateMedicalRecordDTO request)
        //{
        //    if (request == null)
        //    {
        //        throw new ArgumentNullException(nameof(request));
        //    }
        //    var medicalRecord = new MedicalRecord(request.Diagnosis, request.Treatment, request.Prescriptions, request.FollowUpDate, request.RecordedAt);

        //    return _medicalRecordRepository.Create(request);
        //}
    }
}
