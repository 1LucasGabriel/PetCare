using Appointment.Application.DTOs.Response;
using Appointment.Domain.Interfaces.IRepositories;
using System;
using System.Collections.Generic;

namespace Appointment.Application.UseCases
{
    public class GetAppointmentsByOwnerUseCase
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public GetAppointmentsByOwnerUseCase(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public List<AppointmentResponseDTO> Run(Guid ownerId)
        {
            return _appointmentRepository.GetAll()
                .FindAll(a => a.OwnerId == ownerId)
                .ConvertAll(a => new AppointmentResponseDTO(
                    a.Id,
                    a.PetId,
                    a.OwnerId,
                    a.VeterinarianId,
                    a.ScheduleStart,
                    a.ScheduleEnd,
                    a.Status,
                    a.Reason,
                    a.Notes,
                    a.CancelReason,
                    a.CreatedAt,
                    a.UpdatedAt));
        }
    }
}
