using Registration.Application.DTOs;
using Registration.Application.DTOs.Response;
using Registration.Domain.Interfaces.IRepositories;
using Registration.Domain.ValueObjects;
using System;

namespace Registration.Application.UseCases
{
    public class LoginOwnerUseCase
    {
        private readonly IOwnerRepository _ownerRepository;

        public LoginOwnerUseCase(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public OwnerResponseDTO Run(LoginDTO request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var owner = _ownerRepository.GetByEmail(new Email(request.Email));
            if (owner == null || owner.Password.Value != request.Password)
            {
                throw new Exception("E-mail ou senha inválidos.");
            }

            return new OwnerResponseDTO(
                owner.Id,
                owner.FullName,
                owner.CPF.Value,
                owner.Email.Value,
                owner.Phone
            );
        }
    }
}
