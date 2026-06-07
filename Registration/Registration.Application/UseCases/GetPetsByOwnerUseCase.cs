using Registration.Application.DTOs.Response;
using Registration.Domain.Interfaces.IRepositories;
using System;
using System.Collections.Generic;

namespace Registration.Application.UseCases
{
    public class GetPetsByOwnerUseCase
    {
        private readonly IPetRepository _petRepository;

        public GetPetsByOwnerUseCase(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public List<PetResponseDTO> Run(Guid ownerId)
        {
            var pets = _petRepository.GetAll().FindAll(pet => pet.OwnerId == ownerId);
            return pets.ConvertAll(pet => new PetResponseDTO(pet.Id, pet.OwnerId, pet.Name, pet.Species, pet.Breed, pet.BirthDate, pet.WeightKg, pet.IsActive));
        }
    }
}
