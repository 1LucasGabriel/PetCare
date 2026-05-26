using Appointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.Domain.Interfaces.IRepositories
{
    public interface IAppointmentRepository
    {
        public void Create(Appointments appointment);
        public void Update(Appointments appointment);
        public void Delete(Guid Id);
        public Appointments GetById(Guid id);
        public List<Appointments> GetAll();

    }
}
