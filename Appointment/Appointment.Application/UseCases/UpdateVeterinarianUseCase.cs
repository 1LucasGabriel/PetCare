using Appointment.Application.DTOs;
using Appointment.Domain.Interfaces.IRepositories;
using Appointment.Domain.ValueObjects;
using System;

namespace Appointment.Application.UseCases
{
    public class UpdateVeterinarianUseCase
    {
        private readonly IVeterinarianRepository _veterinarianRepository;

        public UpdateVeterinarianUseCase(IVeterinarianRepository veterinarianRepository)
        {
            _veterinarianRepository = veterinarianRepository;
        }

        public bool Run(Guid id, UpdateVeterinarianDTO request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var vet = _veterinarianRepository.GetById(id);
            if (vet == null)
            {
                throw new Exception("Veterinário não encontrado.");
            }

            Password finalPassword = string.IsNullOrWhiteSpace(request.Password) ? vet.Password : new Password(request.Password);
            vet.Update(new Email(request.Email), finalPassword, request.Specialties);
            _veterinarianRepository.Update(vet);
            return true;
        }
    }
}
