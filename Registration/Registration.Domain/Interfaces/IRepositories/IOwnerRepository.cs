using Registration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Domain.Interfaces.IRepositories
{
    public interface IOwnerRepository
    {
        public void Create(Owner owner);
        public Owner GetById (Guid id);
        public List<Owner> GetAll();
        public void Update(Owner owner);
        public void Delete(Guid id);
    }
}
