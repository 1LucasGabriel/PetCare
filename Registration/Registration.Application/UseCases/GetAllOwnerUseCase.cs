using Registration.Application.DTOs;
using Registration.Application.DTOs.Response;
using Registration.Domain.Entities;
using Registration.Domain.Interfaces.IRepositories;
using Registration.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Application.UseCases
{
    public class GetAllOwnerUseCase
    {
        private readonly IOwnerRepository _ownerRepository;
        public GetAllOwnerUseCase(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        public List<OwnerResponseDTO> Run()
        {
            return _ownerRepository.GetAll().ConvertAll(owner => new OwnerResponseDTO(owner.Id, owner.FullName, owner.CPF.Value, owner.Email.Value, owner.Phone));
        }
    }
}
