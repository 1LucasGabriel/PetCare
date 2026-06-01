using Appointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.Domain.Interfaces.IRepositories
{
    public interface IAppointmentRepository
    {
        public Guid Create(AppointmentEntity appointment);
        public AppointmentEntity? GetById(Guid id);
        public List<AppointmentEntity> GetAll();
        public List<AppointmentEntity> GetByVeterinarianId(Guid veterinarianId);
        public List<AppointmentEntity> GetByPetId(Guid petId);
        public void Update(AppointmentEntity appointment);
        public void Delete(Guid id);
    }
}

