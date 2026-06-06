using Appointment.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeleteVeterinarianController : ControllerBase
    {
        private readonly DeleteVeterinarianUseCase _deleteVeterinarianUseCase;

        public DeleteVeterinarianController(DeleteVeterinarianUseCase deleteVeterinarianUseCase)
        {
            _deleteVeterinarianUseCase = deleteVeterinarianUseCase;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _deleteVeterinarianUseCase.Run(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
