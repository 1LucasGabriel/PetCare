using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.Domain.Entities
{
    public class Veterinarian
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string LicenseNumber { get; private set; }
        public string Specialty { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public ICollection<Appointments> Appointments { get; private set; } = new List<Appointments>();

        public Veterinarian(string fullName, string licenseNumber, string specialty)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Full name is required.");

            if (string.IsNullOrWhiteSpace(licenseNumber))
                throw new ArgumentException("License number is required.");

            if (string.IsNullOrWhiteSpace(specialty))
                throw new ArgumentException("Specialty is required.");

            Id = Guid.NewGuid();
            FullName = fullName;
            LicenseNumber = licenseNumber;
            Specialty = specialty;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public Veterinarian() { }
    }
}

