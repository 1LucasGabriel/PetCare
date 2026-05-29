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
                _dataBase.Apt_Veterinaries.Add(veterinarian);
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
            return _dataBase.Apt_Veterinaries.FirstOrDefault(v => v.Id == id);
        }

        public List<Veterinarian> GetAll()
        {
            return _dataBase.Apt_Veterinaries.ToList();
        }

        public void Update(Veterinarian veterinarian)
        {
            _dataBase.Apt_Veterinaries.Update(veterinarian);
            _dataBase.SaveChanges();
        }

        public void Delete(Guid id)
        {
            try
            {
                var veterinarian = GetById(id);
                if (veterinarian != null)
                {
                    _dataBase.Apt_Veterinaries.Remove(veterinarian);
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
