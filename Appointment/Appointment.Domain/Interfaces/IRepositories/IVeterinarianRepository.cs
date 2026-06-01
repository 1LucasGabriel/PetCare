using System;
using System.Collections.Generic;
using System.Text;
using Appointment.Domain.Entities;

namespace Appointment.Domain.Interfaces.IRepositories
{
    public interface IVeterinarianRepository
    {
        public Guid Create(Veterinarian veterinarian);
        public Veterinarian? GetById(Guid id);
        public List<Veterinarian> GetAll();
        public void Update(Veterinarian veterinarian);
        public void Delete(Guid id);
    }
}

