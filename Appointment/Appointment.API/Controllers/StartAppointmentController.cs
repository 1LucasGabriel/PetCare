using Appointment.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StartAppointmentController : ControllerBase
    {
        private readonly StartAppointmentUseCase _startAppointmentUseCase;

        public StartAppointmentController(StartAppointmentUseCase startAppointmentUseCase)
        {
            _startAppointmentUseCase = startAppointmentUseCase;
        }

        [HttpPatch("{id}")]
        public IActionResult Start(Guid id)
        {
            try
            {
                _startAppointmentUseCase.Run(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
