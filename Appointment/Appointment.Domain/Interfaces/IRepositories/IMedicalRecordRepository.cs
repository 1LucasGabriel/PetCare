using Appointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.Domain.Interfaces.IRepositories
{
    public interface IMedicalRecordRepository
    {
        public void Create(MedicalRecord medicalRecord);
        public void Update(MedicalRecord medicalRecord);
        public void Delete(Guid Id);
        public MedicalRecord GetById(Guid id);
        public List<MedicalRecord> GetAll();
    }
}
