using Appointment.Application.DTOs;
using Appointment.Domain.Entities;
using Appointment.Domain.Interfaces.IRepositories;
using Appointment.Domain.ValueObjects;
using System;

namespace Appointment.Application.UseCases
{
    public class CreateVeterinarianUseCase
    {
        private readonly IVeterinarianRepository _veterinarianRepository;

        public CreateVeterinarianUseCase(IVeterinarianRepository veterinarianRepository)
        {
            _veterinarianRepository = veterinarianRepository;
        }

        public Guid Run(CreateVeterinarianDTO request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var existing = _veterinarianRepository.GetByEmail(new Email(request.Email));
            if (existing != null)
            {
                throw new Exception("Já existe um veterinário cadastrado com este e-mail.");
            }
 
            var existingByCrmv = _veterinarianRepository.GetByCrmv(request.Crmv);
            if (existingByCrmv != null)
            {
                throw new Exception("Já existe um veterinário cadastrado com este CRMV.");
            }

            var vet = new Veterinarian();
            vet.Create(
                request.FullName,
                request.Crmv,
                new Email(request.Email),
                new Password(request.Password),
                request.Specialties
            );

            return _veterinarianRepository.Create(vet);
        }
    }
}
