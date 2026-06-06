using Appointment.Application.DTOs;
using Appointment.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UpdateVeterinarianController : ControllerBase
    {
        private readonly UpdateVeterinarianUseCase _updateVeterinarianUseCase;

        public UpdateVeterinarianController(UpdateVeterinarianUseCase updateVeterinarianUseCase)
        {
            _updateVeterinarianUseCase = updateVeterinarianUseCase;
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] UpdateVeterinarianDTO request)
        {
            try
            {
                _updateVeterinarianUseCase.Run(id, request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
