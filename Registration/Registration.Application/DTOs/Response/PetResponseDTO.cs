using Registration.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Application.DTOs.Response
{
    public class PetResponseDTO
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public Species Species { get; set; }
        public string Breed { get; set; }
        public DateTime? BirthDate { get; set; }
        public decimal WeightKg { get; set; }
        public bool IsActive { get; set; } = true;

        public PetResponseDTO(Guid id, Guid ownerId, string name, Species species, string breed, DateTime? birthDate, decimal weightKg, bool isActive)
        {
            Id = id;
            OwnerId = ownerId;
            Name = name;
            Species = species;
            Breed = breed;
            BirthDate = birthDate;
            WeightKg = weightKg;
            IsActive = isActive;
        }
    }
}
