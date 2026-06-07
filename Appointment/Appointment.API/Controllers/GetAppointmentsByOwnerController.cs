using Appointment.Application.DTOs.Response;
using Appointment.Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Appointment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetAppointmentsByOwnerController : ControllerBase
    {
        private readonly GetAppointmentsByOwnerUseCase _getAppointmentsByOwnerUseCase;

        public GetAppointmentsByOwnerController(GetAppointmentsByOwnerUseCase getAppointmentsByOwnerUseCase)
        {
            _getAppointmentsByOwnerUseCase = getAppointmentsByOwnerUseCase;
        }

        [HttpGet("{ownerId}")]
        public IActionResult Get(Guid ownerId)
        {
            try
            {
                List<AppointmentResponseDTO> appointments = _getAppointmentsByOwnerUseCase.Run(ownerId);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
