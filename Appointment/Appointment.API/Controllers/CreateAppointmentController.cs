using Appointment.Application.DTOs;
using Appointment.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreateAppointmentController : ControllerBase
    {
        private readonly CreateAppointmentUseCase _createAppointmentUseCase;

        public CreateAppointmentController(CreateAppointmentUseCase createAppointmentUseCase)
        {
            _createAppointmentUseCase = createAppointmentUseCase;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateAppointmentDTO request)
        {
            try
            {
                Guid id = _createAppointmentUseCase.Run(request);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
