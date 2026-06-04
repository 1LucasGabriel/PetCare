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
                throw new Exception("Veterinarian not found.");
            }

            vet.Update(new Email(request.Email), request.Password, request.Specialties);
            _veterinarianRepository.Update(vet);
            return true;
        }
    }
}
