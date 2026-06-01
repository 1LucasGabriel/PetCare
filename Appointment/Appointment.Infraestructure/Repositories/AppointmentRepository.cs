using Appointment.Domain.Entities;
using Appointment.Domain.Interfaces.IRepositories;
using Appointment.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Appointment.Infrastructure.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _dataBase;

        public AppointmentRepository(AppDbContext dataBase)
        {
            _dataBase = dataBase;
        }

        public Guid Create(AppointmentEntity appointment)
        {
            try
            {
                _dataBase.Appt_Appointment.Add(appointment);
                _dataBase.SaveChanges();
                return appointment.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public AppointmentEntity? GetById(Guid id)
        {
            return _dataBase.Appt_Appointment
                .Include(a => a.Veterinarian)
                .Include(a => a.MedicalRecord)
                .FirstOrDefault(a => a.Id == id);
        }

        public List<AppointmentEntity> GetAll()
        {
            return _dataBase.Appt_Appointment
                .Include(a => a.Veterinarian)
                .ToList();
        }

        public List<AppointmentEntity> GetByVeterinarianId(Guid veterinarianId)
        {
            return _dataBase.Appt_Appointment
                .Where(a => a.VeterinarianId == veterinarianId)
                .ToList();
        }

        public List<AppointmentEntity> GetByPetId(Guid petId)
        {
            return _dataBase.Appt_Appointment
                .Where(a => a.PetId == petId)
                .ToList();
        }

        public void Update(AppointmentEntity appointment)
        {
            _dataBase.Appt_Appointment.Update(appointment);
            _dataBase.SaveChanges();
        }

        public void Delete(Guid id)
        {
            try
            {
                var appointment = GetById(id);
                if (appointment != null)
                {
                    _dataBase.Appt_Appointment.Remove(appointment);
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
