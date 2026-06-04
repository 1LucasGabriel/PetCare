using Appointment.Application.DTOs.Response;
using Appointment.Domain.Interfaces.IRepositories;
using System.Collections.Generic;

namespace Appointment.Application.UseCases
{
    public class GetAllVeterinariansUseCase
    {
        private readonly IVeterinarianRepository _veterinarianRepository;

        public GetAllVeterinariansUseCase(IVeterinarianRepository veterinarianRepository)
        {
            _veterinarianRepository = veterinarianRepository;
        }

        public List<VeterinarianResponseDTO> Run()
        {
            return _veterinarianRepository.GetAll().ConvertAll(vet => new VeterinarianResponseDTO(
                vet.Id,
                vet.FullName,
                vet.Crmv,
                vet.Email.Value,
                vet.Specialties,
                vet.IsActive
            ));
        }
    }
}
