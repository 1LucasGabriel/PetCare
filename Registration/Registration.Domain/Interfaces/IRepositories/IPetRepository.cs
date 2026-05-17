using Registration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Domain.Interfaces.IRepositories
{
    public interface IPetRepository
    {
        public void Create(Pet pet);
        public Pet GetById(Guid id);
        public List<Pet> GetAll();
        public void Update(Pet pet);
        public void Delete(Guid id);
    }
}
