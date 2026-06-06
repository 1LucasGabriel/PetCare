using Registration.Domain.Interfaces.IRepositories;
using Registration.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Application.UseCases
{
    public class DeletePetUseCase
    {
        private readonly IPetRepository _petRepository;
        private readonly IAppointmentService _appointmentService;
        public DeletePetUseCase(IPetRepository petRepository, IAppointmentService appointmentService)
        {
            _petRepository = petRepository;
            _appointmentService = appointmentService;
        }

        public async Task Run(Guid id)
        {
            var pet = _petRepository.GetById(id);

            if (pet == null)
            {
                throw new Exception("Pet not found.");
            }

            var hasFuture = await _appointmentService.HasFutureAppointmentsAsync(id);

            if (hasFuture)
                throw new Exception("Pet cannot be deleted with future appointments.");

            _petRepository.Delete(id);
        }
    }
}
