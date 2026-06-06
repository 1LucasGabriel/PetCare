using Microsoft.AspNetCore.Mvc;
using Registration.Application.DTOs;
using Registration.Application.UseCases;

namespace Registration.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UpdatePetController : ControllerBase
    {
        private readonly UpdatePetUseCase _updatePetUseCase;

        public UpdatePetController(UpdatePetUseCase updatePetUseCase)
        {
            _updatePetUseCase = updatePetUseCase;
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] UpdatePetDTO request)
        {
            try
            {
                _updatePetUseCase.Run(id, request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
