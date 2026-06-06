using Appointment.Application.DTOs.Response;
using Appointment.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetAppointmentController : ControllerBase
    {
        private readonly GetAppointmentUseCase _getAppointmentUseCase;

        public GetAppointmentController(GetAppointmentUseCase getAppointmentUseCase)
        {
            _getAppointmentUseCase = getAppointmentUseCase;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                AppointmentResponseDTO appointment = _getAppointmentUseCase.Run(id);
                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
