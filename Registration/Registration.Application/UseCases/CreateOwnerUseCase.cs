using Registration.Application.DTOs;
using Registration.Domain.Entities;
using Registration.Domain.Interfaces.IRepositories;
using Registration.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Application.UseCases
{
    public class CreateOwnerUseCase
    {
        private readonly IOwnerRepository _ownerRepository;
        public CreateOwnerUseCase(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        public Guid Run(CreateOwnerDTO request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Owner? user = _ownerRepository.GetByEmail(new Email(request.Email));
            if (user != null)
            {
                throw new Exception("Já existe um dono cadastrado com este e-mail.");
            }

            Owner? userByCPF = _ownerRepository.GetByCPF(new CPF(request.CPF));
            if (userByCPF != null)
            {
                throw new Exception("Já existe um dono cadastrado com este CPF.");
            }

            var newOwner = new Owner(request.FullName, new CPF(request.CPF), new Email(request.Email), new Password(request.Password), request.Phone);

            return _ownerRepository.Create(newOwner);
        }
    }
}
