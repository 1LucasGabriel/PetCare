using System;
using System.Collections.Generic;
using System.Text;
using Appointment.Domain.Entities;
using Appointment.Domain.Interfaces.IRepositories;
using Appointment.Infrastructure.Persistence;

namespace Appointment.Infrastructure.Repositories
{
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        public readonly AppDbContext _dataBase;

        public MedicalRecordRepository(AppDbContext dataBase)
        {
            _dataBase = dataBase;
        }
        public void Create(MedicalRecord medicalRecord)
        {
            try
            {
                _dataBase.Reg_MedicalRecords.Add(medicalRecord);
                _dataBase.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(MedicalRecord medicalRecord)
        {
            _dataBase.Reg_MedicalRecords.Update(medicalRecord);
            _dataBase.SaveChanges();
        }

        public void Delete(Guid Id)
        {
            try
            {
                var medicalRecord = GetById(Id);
                _dataBase.Reg_MedicalRecords.Remove(medicalRecord);
                _dataBase.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public MedicalRecord GetById(Guid id)
        {
            return _dataBase.Reg_MedicalRecords.FirstOrDefault(medicalRecord => medicalRecord.Id == id);
        }

        public List<MedicalRecord> GetAll()
        {
            return _dataBase.Reg_MedicalRecords.ToList();
        }
    }
}