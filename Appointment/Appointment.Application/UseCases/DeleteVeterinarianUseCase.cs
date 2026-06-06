using Appointment.Domain.Interfaces.IRepositories;
using System;
using System.Linq;

namespace Appointment.Application.UseCases
{
    public class DeleteVeterinarianUseCase
    {
        private readonly IVeterinarianRepository _veterinarianRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public DeleteVeterinarianUseCase(IVeterinarianRepository veterinarianRepository, IAppointmentRepository appointmentRepository)
        {
            _veterinarianRepository = veterinarianRepository;
            _appointmentRepository = appointmentRepository;
        }

        public bool Run(Guid id)
        {
            var vet = _veterinarianRepository.GetById(id);
            if (vet == null)
            {
                throw new Exception("Veterinário não encontrado.");
            }

            var appointments = _appointmentRepository.GetByVeterinarianId(id);
            if (appointments != null && appointments.Any())
            {
                throw new Exception("Não é possível deletar o veterinário porque há consultas associadas a ele.");
            }

            _veterinarianRepository.Delete(id);
            return true;
        }
    }
}
