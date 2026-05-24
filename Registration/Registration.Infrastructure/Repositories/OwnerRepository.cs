using Microsoft.EntityFrameworkCore;
using Registration.Domain.Entities;
using Registration.Domain.Interfaces.IRepositories;
using Registration.Domain.ValueObjects;
using Registration.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Infrastructure.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        public readonly AppDbContext _dataBase;

        public OwnerRepository(AppDbContext dataBase)
        {
            _dataBase = dataBase;
        }

        public Guid Create(Owner owner)
        {
            try
            {
                _dataBase.Reg_Owners.Add(owner);
                _dataBase.SaveChanges();
                return Guid.NewGuid();
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
                var owner = GetById(id);
                _dataBase.Reg_Owners.Remove(owner);
                _dataBase.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Owner> GetAll()
        {
            return _dataBase.Reg_Owners.ToList();
        }

        public Owner GetById(Guid id)
        {
            return _dataBase.Reg_Owners.FirstOrDefault(owner => owner.Id == id);
        }

        public Owner? GetByEmail(Email email)
        {
            return _dataBase.Reg_Owners.FirstOrDefault(x => x.Email.Value == email.Value);
        }

        public void Update(Owner owner)
        {
            _dataBase.Reg_Owners.Update(owner);
            _dataBase.SaveChanges();
        }
    }
}
