using Appointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.Domain.Interfaces.IRepositories
{
    public interface IAppointmentRepository
    {
        public Guid Create(Appointment appointment);
        public Appointment? GetById(Guid id);
        public List<Appointment> GetAll();
        public List<Appointment> GetByVeterinarianId(Guid veterinarianId);
        public List<Appointment> GetByPetId(Guid petId);
        public void Update(Appointment appointment);
        public void Delete(Guid id);
    }
}

