using Registration.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Domain.Entities
{
    public class Pet
    {
        public Guid Id { get; private set; }
        public Guid OwnerId { get; private set; }
        public string Name { get; private set; }
        public Species Species { get; private set; }
        public string Breed { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public decimal WeightKg { get; private set; }
        public bool IsActive { get; private set; } = true;
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
    }
}
