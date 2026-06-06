using Appointment.Application.DTOs.Response;
using Appointment.Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Appointment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetAllAppointmentController : ControllerBase
    {
        private readonly GetAllAppointmentsUseCase _getAllAppointmentsUseCase;

        public GetAllAppointmentController(GetAllAppointmentsUseCase getAllAppointmentsUseCase)
        {
            _getAllAppointmentsUseCase = getAllAppointmentsUseCase;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<AppointmentResponseDTO> appointments = _getAllAppointmentsUseCase.Run();
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
