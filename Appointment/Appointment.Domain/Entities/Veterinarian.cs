using Appointment.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.Domain.Entities
{
    public class Veterinarian
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Crmv { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }
        public List<string>? Specialties { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public void Create(string fullName, string crmv, Email email, Password password, List<string>? specialties)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException("Nome do veterinario não pode estar vazio.");
            }

            if (string.IsNullOrWhiteSpace(crmv))
            {
                throw new ArgumentException("CRMV não pode estar vazio.");
            }

            if (string.IsNullOrWhiteSpace(email.Value))
            {
                throw new ArgumentException("Email não pode estar vazio.");
            }

            Id = Guid.NewGuid();
            FullName = fullName;
            Crmv = crmv;
            Email = email;
            Password = password;
            Specialties = specialties;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Update(Email email, Password password, List<string>? specialties)
        {
            Email = email;
            Password = password;
            Specialties = specialties;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Activate()
        {
            IsActive = true;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Deactivate(bool hasScheduledOrInProgressAppointments)
        {
            if (hasScheduledOrInProgressAppointments)
            {
                throw new ArgumentException("Veterinario não pode ser desativado com consultas agendadas ou em andamento.");
            }

            IsActive = false;
            UpdatedAt = DateTime.UtcNow;
        }

        public void VerifyCanBeAssignedToAppointment()
        {
            if (!IsActive)
            {
                throw new ArgumentException("Veterinario inativo não pode receber novas consultas.");
            }
        }
    }
}
