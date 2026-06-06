using Registration.Application.DTOs.Response;
using Registration.Domain.Entities;
using Registration.Domain.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Application.UseCases
{
    public class GetPetUseCase
    {
        private readonly IPetRepository _petRepository;
        public GetPetUseCase(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }
        public PetResponseDTO Run(Guid id)
        {
            var pet = _petRepository.GetById(id);

            if (pet == null)
            {
                throw new Exception("Pet não encontrado.");
            }

            return new PetResponseDTO(pet.Id, pet.OwnerId, pet.Name, pet.Species, pet.Breed, pet.BirthDate, pet.WeightKg, pet.IsActive);
        }
    }
}
