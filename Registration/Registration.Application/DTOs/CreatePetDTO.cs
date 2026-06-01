using Registration.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Application.DTOs
{
    public class CreatePetDTO
    {
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public Species Species { get; set; }
        public string Breed { get; set; }
        public DateTime? BirthDate { get; set; }
        public decimal WeightKg { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
