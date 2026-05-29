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
        public string Password { get; private set; }
        public List<string>? Specialties { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public void Create(string fullName, string crmv, Email email, string password, List<string>? specialties)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException("Nome do veterinario não pode estar vazio.");
            }

            if (string.IsNullOrWhiteSpace(crmv))
            {
                throw new ArgumentException("CRMV não pode estar vazio.");
            }

            if (Email.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentoException("Email não pode estar vazio.");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentoException("Senha não pode estar vazio.");
            }

            Id = Guid.NewGuid();
            FullName = fullName;
            Crmv = crmv;
            Email = email;
            Password = password;
            Specialties = specialties;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
        }

        public void Update(Email email, string password, List<string>? specialties)
        {
            Email = email;
            Password = password;
            Specialties = specialties;
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate(bool hasScheduledOrInProgressAppointments)
        {
            if (hasScheduledOrInProgressAppointments)
            {
                throw new ArgumentException("Veterinario não pode ser desativado com consultas agendadas ou em andamento.");
            }

            IsActive = false;
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
