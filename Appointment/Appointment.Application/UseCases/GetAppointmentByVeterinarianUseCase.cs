using System;
using System.Collections.Generic;
using System.Text;
using Appointment.Application.DTOs.Response;
using Appointment.Domain.Interfaces.IRepositories;

namespace Appointment.Application.UseCases
{
    public class GetAppointmentByVeterinarianUseCase
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public GetAppointmentByVeterinarianUseCase(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public List<AppointmentResponseDTO> Run(Guid veterinarianId)
        {
            return _appointmentRepository.GetByVeterinarianId(veterinarianId).ConvertAll(a => new AppointmentResponseDTO(
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