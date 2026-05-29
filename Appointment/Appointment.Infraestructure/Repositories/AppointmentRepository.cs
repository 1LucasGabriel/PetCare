using System;
using System.Collections.Generic;
using System.Text;
using Appointment.Domain.Interfaces.IRepositories;
using Appointment.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
/*
namespace Appointment.Infrastructure.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _dataBase;

        public AppointmentRepository(AppDbContext dataBase)
        {
            _dataBase = dataBase;
        }

        public Guid Create(Domain.Entities.Appointment appointment)
        {
            try
            {
                _dataBase.Apt_Appointments.Add(appointment);
                _dataBase.SaveChanges();
                return appointment.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Domain.Entities.Appointment? GetById(Guid id)
        {
            return _dataBase.Apt_Appointments
                .Include(a => a.Veterinarian)
                .Include(a => a.MedicalRecord)
                .FirstOrDefault(a => a.Id == id);
        }

        public List<Domain.Entities.Appointment> GetAll()
        {
            return _dataBase.Apt_Appointments
                .Include(a => a.Veterinarian)
                .ToList();
        }

        public List<Domain.Entities.Appointment> GetByVeterinarianId(Guid veterinarianId)
        {
            return _dataBase.Apt_Appointments
                .Where(a => a.VeterinarianId == veterinarianId)
                .ToList();
        }

        public List<Domain.Entities.Appointment> GetByPetId(Guid petId)
        {
            return _dataBase.Apt_Appointments
                .Where(a => a.PetId == petId)
                .ToList();
        }

        public void Update(Domain.Entities.Appointment appointment)
        {
            _dataBase.Apt_Appointments.Update(appointment);
            _dataBase.SaveChanges();
        }

        public void Delete(Guid id)
        {
            try
            {
                var appointment = GetById(id);
                if (appointment != null)
                {
                    _dataBase.Apt_Appointments.Remove(appointment);
                    _dataBase.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
*/