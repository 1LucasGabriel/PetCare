using Registration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Domain.Interfaces.IRepositories
{
    public interface IPetRepository
    {
        public Guid Create(Pet pet);
        public Pet GetById(Guid id);
        public List<Pet> GetAll();
        public List<Pet> GetByOwnerId(Guid ownerId);
        public void Update(Pet pet);
        public void Delete(Guid id);
    }
}
