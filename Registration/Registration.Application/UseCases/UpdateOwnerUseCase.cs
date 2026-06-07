using Registration.Application.DTOs;
using Registration.Domain.Interfaces.IRepositories;
using Registration.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Application.UseCases
{
    public class UpdateOwnerUseCase
    {
        private readonly IOwnerRepository _ownerRepository;
        public UpdateOwnerUseCase(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public bool Run(Guid id, UpdateOwnerDTO request)
        {
            var owner = _ownerRepository.GetById(id);

            if (owner == null)
            {
                throw new Exception("Dono não encontrado.");
            }

            string finalPassword = string.IsNullOrWhiteSpace(request.Password) ? owner.Password : request.Password;
            owner.Update(new Email(request.Email), request.Phone, finalPassword);
            _ownerRepository.Update(owner);
            return true;
        }
    }
}
