using Registration.Domain.Entities;
using Registration.Domain.Interfaces.IRepositories;
using Registration.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Infrastructure.Repositories
{
    public class PetRepository : IPetRepository
    {
        public readonly AppDbContext _dataBase;

        public PetRepository(AppDbContext dataBase)
        {
            _dataBase = dataBase;
        }

        public void Create(Pet pet)
        {
            try
            {
                _dataBase.Reg_Pets.Add(pet);
                _dataBase.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                var pet = GetById(id);
                _dataBase.Reg_Pets.Remove(pet);
                _dataBase.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Pet> GetAll()
        {
            return _dataBase.Reg_Pets.ToList();
        }

        public Pet GetById(Guid id)
        {
            return _dataBase.Reg_Pets.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Pet pet)
        {
            _dataBase.Reg_Pets.Update(pet);
            _dataBase.SaveChanges();
        }
    }
}
