using System;
using System.Collections.Generic;
using System.Text;
using Appointment.Domain.Entities;

using Appointment.Domain.ValueObjects;

namespace Appointment.Domain.Interfaces.IRepositories
{
    public interface IVeterinarianRepository
    {
        public Guid Create(Veterinarian veterinarian);
        public Veterinarian? GetById(Guid id);
        public Veterinarian? GetByEmail(Email email);
        public Veterinarian? GetByCrmv(string crmv);
        public List<Veterinarian> GetAll();
        public void Update(Veterinarian veterinarian);
        public void Delete(Guid id);
    }
}

