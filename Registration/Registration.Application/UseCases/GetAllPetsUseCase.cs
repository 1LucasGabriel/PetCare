using Registration.Application.DTOs.Response;
using Registration.Domain.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Application.UseCases
{
    public class GetAllPetsUseCase
    {
        private readonly IPetRepository _petRepository;
        public GetAllPetsUseCase(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }
        public List<PetResponseDTO> Run()
        {
            return _petRepository.GetAll().ConvertAll(pet => new PetResponseDTO(pet.Id, pet.OwnerId, pet.Name, pet.Species, pet.Breed, pet.BirthDate, pet.WeightKg, pet.IsActive));
        }
    }
}
