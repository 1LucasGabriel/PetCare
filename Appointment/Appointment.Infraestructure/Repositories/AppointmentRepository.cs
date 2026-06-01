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

        public Guid Create(Appointments appointment)
        {
            try
            {
                _dataBase.Appo_Appointments.Add(appointment);
                _dataBase.SaveChanges();
                return appointment.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Appointments? GetById(Guid id)
        {
            return _dataBase.Appo_Appointments
                .Include(a => a.Veterinarian)
                .Include(a => a.MedicalRecord)
                .FirstOrDefault(a => a.Id == id);
        }

        public List<Appointments> GetAll()
        {
            return _dataBase.Appo_Appointments
                .Include(a => a.Veterinarian)
                .ToList();
        }

        public List<Appointments> GetByVeterinarianId(Guid veterinarianId)
        {
            return _dataBase.Appo_Appointments
                .Where(a => a.VeterinarianId == veterinarianId)
                .ToList();
        }

        public List<Appointments> GetByPetId(Guid petId)
        {
            return _dataBase.Appo_Appointments
                .Where(a => a.PetId == petId)
                .ToList();
        }

        public void Update(Appointments appointment)
        {
            _dataBase.Appo_Appointments.Update(appointment);
            _dataBase.SaveChanges();
        }

        public void Delete(Guid id)
        {
            try
            {
                var appointment = GetById(id);
                if (appointment != null)
                {
                    _dataBase.Appo_Appointments.Remove(appointment);
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
