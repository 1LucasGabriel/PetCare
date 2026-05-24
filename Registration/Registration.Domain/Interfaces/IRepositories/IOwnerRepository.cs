using Registration.Domain.Entities;
using Registration.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Domain.Interfaces.IRepositories
{
    public interface IOwnerRepository
    {
        public Guid Create(Owner owner);
        public Owner GetById (Guid id);
        public Owner? GetByEmail(Email email);
        public List<Owner> GetAll();
        public void Update(Owner owner);
        public void Delete(Guid id);
    }
}
