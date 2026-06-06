using Appointment.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompleteAppointmentController : ControllerBase
    {
        private readonly CompleteAppointmentUseCase _completeAppointmentUseCase;

        public CompleteAppointmentController(CompleteAppointmentUseCase completeAppointmentUseCase)
        {
            _completeAppointmentUseCase = completeAppointmentUseCase;
        }

        [HttpPatch("{id}")]
        public IActionResult Complete(Guid id)
        {
            try
            {
                _completeAppointmentUseCase.Run(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
