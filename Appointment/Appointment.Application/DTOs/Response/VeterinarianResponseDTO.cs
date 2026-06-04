using System;
using System.Collections.Generic;

namespace Appointment.Application.DTOs.Response
{
    public class VeterinarianResponseDTO
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Crmv { get; set; }
        public string Email { get; set; }
        public List<string>? Specialties { get; set; }
        public bool IsActive { get; set; }

        public VeterinarianResponseDTO(Guid id, string fullName, string crmv, string email, List<string>? specialties, bool isActive)
        {
            Id = id;
            FullName = fullName;
            Crmv = crmv;
            Email = email;
            Specialties = specialties;
            IsActive = isActive;
        }
    }
}
