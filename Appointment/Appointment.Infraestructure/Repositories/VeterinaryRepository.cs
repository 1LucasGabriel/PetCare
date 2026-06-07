using Appointment.Domain.Entities;
using Appointment.Domain.Interfaces.IRepositories;
using Appointment.Infrastructure.Persistence;

namespace Appointment.Infrastructure.Repositories
{
    public class VeterinarianRepository : IVeterinarianRepository
    {
        private readonly AppDbContext _dataBase;

        public VeterinarianRepository(AppDbContext dataBase)
        {
            _dataBase = dataBase;
        }

        public Guid Create(Veterinarian veterinarian)
        {
            try
            {
                _dataBase.Appt_Veterinarians.Add(veterinarian);
                _dataBase.SaveChanges();
                return veterinarian.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Veterinarian? GetById(Guid id)
        {
            return _dataBase.Appt_Veterinarians.FirstOrDefault(v => v.Id == id);
        }

        public Veterinarian? GetByEmail(Appointment.Domain.ValueObjects.Email email)
        {
            return _dataBase.Appt_Veterinarians.FirstOrDefault(v => v.Email.Value == email.Value);
        }
 
        public Veterinarian? GetByCrmv(string crmv)
        {
            return _dataBase.Appt_Veterinarians.FirstOrDefault(v => v.Crmv == crmv);
        }

        public List<Veterinarian> GetAll()
        {
            return _dataBase.Appt_Veterinarians.ToList();
        }

        public void Update(Veterinarian veterinarian)
        {
            _dataBase.Appt_Veterinarians.Update(veterinarian);
            _dataBase.SaveChanges();
        }

        public void Delete(Guid id)
        {
            try
            {
                var veterinarian = GetById(id);
                if (veterinarian != null)
                {
                    _dataBase.Appt_Veterinarians.Remove(veterinarian);
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
