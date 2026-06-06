using Appointment.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeleteAppointmentController : ControllerBase
    {
        private readonly DeleteAppointmentUseCase _deleteAppointmentUseCase;

        public DeleteAppointmentController(DeleteAppointmentUseCase deleteAppointmentUseCase)
        {
            _deleteAppointmentUseCase = deleteAppointmentUseCase;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _deleteAppointmentUseCase.Run(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
