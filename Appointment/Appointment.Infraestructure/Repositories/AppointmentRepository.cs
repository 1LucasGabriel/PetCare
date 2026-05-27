using System;
using System.Collections.Generic;
using System.Text;
using Appointment.Domain.Entities;
using Appointment.Domain.Interfaces.IRepositories;
using Appointment.Infrastructure.Persistence;

namespace Appointment.Infrastructure.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        public readonly AppDbContext _dataBase;

        public AppointmentRepository(AppDbContext dataBase)
        {
            _dataBase = dataBase;
        }
        public void Create(Appointments appointment)
        {
            try
            {
                _dataBase.Appo_Appointments.Add(appointment);
                _dataBase.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Appointments appointment)
        {
            _dataBase.Appo_Appointments.Update(appointment);
            _dataBase.SaveChanges();
        }

        public void Delete(Guid Id)
        {
            try
            {
                var appointment = GetById(Id);
                _dataBase.Appo_Appointments.Remove(appointment);
                _dataBase.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Appointments GetById(Guid id)
        {
            return _dataBase.Appo_Appointments.FirstOrDefault(appointment => appointment.Id == id);
        }

        public List<Appointments> GetAll()
        {
            return _dataBase.Appo_Appointments.ToList();
        }
    }
}
