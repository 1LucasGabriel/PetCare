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
                throw new Exception("There is already a veterinarian with this email.");
            }

            var vet = new Veterinarian();
            vet.Create(
                request.FullName,
                request.Crmv,
                new Email(request.Email),
                request.Password,
                request.Specialties
            );

            return _veterinarianRepository.Create(vet);
        }
    }
}
