using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.Domain.Entitiess
{
    public class Veterinarian
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Crmv { get; private set; }
        public List<string>? Specialties { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
