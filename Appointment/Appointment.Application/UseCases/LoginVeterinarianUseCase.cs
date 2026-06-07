using Appointment.Application.DTOs;
using Appointment.Application.DTOs.Response;
using Appointment.Domain.Interfaces.IRepositories;
using Appointment.Domain.ValueObjects;
using System;

namespace Appointment.Application.UseCases
{
    public class LoginVeterinarianUseCase
    {
        private readonly IVeterinarianRepository _veterinarianRepository;

        public LoginVeterinarianUseCase(IVeterinarianRepository veterinarianRepository)
        {
            _veterinarianRepository = veterinarianRepository;
        }

        public VeterinarianResponseDTO Run(LoginDTO request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var vet = _veterinarianRepository.GetByEmail(new Email(request.Email));
            if (vet == null || vet.Password.Value != request.Password)
            {
                throw new Exception("E-mail ou senha inválidos.");
            }

            return new VeterinarianResponseDTO(
                vet.Id,
                vet.FullName,
                vet.Crmv,
                vet.Email.Value,
                vet.Specialties,
                vet.IsActive
            );
        }
    }
}
