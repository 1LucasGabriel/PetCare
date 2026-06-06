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

        public void Create(Guid ownerId, string name, Species species, string breed, DateTime? birthDate, decimal weightKg)
        {
            if (ownerId == Guid.Empty)
            {
                throw new ArgumentException("O ID do dono não pode estar vazio.");
            }

            if (birthDate != null && birthDate > DateTime.UtcNow)
            {
                throw new ArgumentException("A data de nascimento não pode ser no futuro.");
            }

            if (weightKg <= 0)
            {
                throw new ArgumentException("O peso deve ser um valor positivo.");
            }

            Id = Guid.NewGuid();
            OwnerId = ownerId;
            Name = name;
            Species = species;
            Breed = breed;
            BirthDate = birthDate;
            WeightKg = weightKg;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Update(string name, decimal weightKg, bool isActive)
        {
            if (weightKg <= 0)
            {
                throw new ArgumentException("O peso deve ser um valor positivo.");
            }

            Name = name;
            WeightKg = weightKg;
            IsActive = isActive;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
