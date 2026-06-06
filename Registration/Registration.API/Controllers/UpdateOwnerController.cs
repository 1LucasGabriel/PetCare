using Microsoft.AspNetCore.Mvc;
using Registration.Application.DTOs;
using Registration.Application.UseCases;

namespace Registration.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UpdateOwnerController : ControllerBase
    {
        private readonly UpdateOwnerUseCase _updateOwnerUseCase;

        public UpdateOwnerController(UpdateOwnerUseCase updateOwnerUseCase)
        {
            _updateOwnerUseCase = updateOwnerUseCase;
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] UpdateOwnerDTO request)
        {
            try
            {
                _updateOwnerUseCase.Run(id, request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
