using Registration.Application.DTOs;
using Registration.Domain.Entities;
using Registration.Domain.Interfaces.IRepositories;
using Registration.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Application.UseCases
{
    public class CreatePetUseCase
    {
        private readonly IPetRepository _petRepository;
        private readonly IOwnerRepository _ownerRepository;
        public CreatePetUseCase(IPetRepository petRepository, IOwnerRepository ownerRepository)
        {
            _petRepository = petRepository;
            _ownerRepository = ownerRepository;
        }
        public Guid Run(CreatePetDTO request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var owner = _ownerRepository.GetById(request.OwnerId);
            if (owner == null)
            {
                throw new ArgumentException("Dono não encontrado.");
            }

            var newPet = new Pet();
            newPet.Create(request.OwnerId, request.Name, request.Species, request.Breed, request.BirthDate, request.WeightKg);

            return _petRepository.Create(newPet);
        }
    }
}
