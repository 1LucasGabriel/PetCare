using Appointment.Application.DTOs.Response;
using Appointment.Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Appointment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetAppointmentsByVetController : ControllerBase
    {
        private readonly GetAppointmentsByVetUseCase _getAppointmentsByVetUseCase;

        public GetAppointmentsByVetController(GetAppointmentsByVetUseCase getAppointmentsByVetUseCase)
        {
            _getAppointmentsByVetUseCase = getAppointmentsByVetUseCase;
        }

        [HttpGet("{vetId}")]
        public IActionResult Get(Guid vetId)
        {
            try
            {
                List<AppointmentResponseDTO> appointments = _getAppointmentsByVetUseCase.Run(vetId);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
