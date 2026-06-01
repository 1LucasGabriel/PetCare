using Registration.Application.DTOs.Response;
using Registration.Domain.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Application.UseCases
{
    public class GetOwnerUseCase
    {
        private readonly IOwnerRepository _ownerRepository;
        public GetOwnerUseCase(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        public OwnerResponseDTO Run(Guid id)
        {
            var owner = _ownerRepository.GetById(id);

            if (owner == null) { 
                throw new Exception("Owner not found.");
            }

            return new OwnerResponseDTO(owner.Id, owner.FullName, owner.CPF.Value, owner.Email.Value, owner.Phone);
        }
    }
}
