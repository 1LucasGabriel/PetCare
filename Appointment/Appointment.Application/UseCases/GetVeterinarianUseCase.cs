using Appointment.Application.DTOs.Response;
using Appointment.Domain.Interfaces.IRepositories;
using System;

namespace Appointment.Application.UseCases
{
    public class GetVeterinarianUseCase
    {
        private readonly IVeterinarianRepository _veterinarianRepository;

        public GetVeterinarianUseCase(IVeterinarianRepository veterinarianRepository)
        {
            _veterinarianRepository = veterinarianRepository;
        }

        public VeterinarianResponseDTO Run(Guid id)
        {
            var vet = _veterinarianRepository.GetById(id);
            if (vet == null)
            {
                throw new Exception("Veterinário não encontrado.");
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
