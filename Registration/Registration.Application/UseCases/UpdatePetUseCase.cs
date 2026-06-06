using Registration.Application.DTOs;
using Registration.Domain.Interfaces.IRepositories;
using Registration.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Application.UseCases
{
    public class UpdatePetUseCase
    {
        private readonly IPetRepository _petRepository;
        public UpdatePetUseCase(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public bool Run(Guid id, UpdatePetDTO request)
        {
            var pet = _petRepository.GetById(id);

            if (pet == null)
            {
                throw new Exception("Pet não encontrado.");
            }

            pet.Update(request.Name, request.WeightKg, request.IsActive);
            _petRepository.Update(pet);
            return true;
        }
    }
}
