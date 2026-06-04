using Appointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.Domain.Interfaces.IRepositories
{
    public interface IAppointmentRepository
    {
        public Guid Create(Appointments appointment);
        public Appointments? GetById(Guid id);
        public List<Appointments> GetAll();
        public List<Appointments> GetByVeterinarianId(Guid veterinarianId);
        public List<Appointments> GetByPetId(Guid petId);
        public List<Appointments> GetByOwnerId(Guid ownerId);
        public void Update(Appointments appointment);
        public void Delete(Guid id);
    }
}

