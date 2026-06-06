using Microsoft.AspNetCore.Mvc;
using Registration.Application.DTOs.Response;
using Registration.Application.UseCases;

namespace Registration.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetOwnerController : ControllerBase
    {
        private readonly GetOwnerUseCase _getOwnerUseCase;

        public GetOwnerController(GetOwnerUseCase getOwnerUseCase)
        {
            _getOwnerUseCase = getOwnerUseCase;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                OwnerResponseDTO owner = _getOwnerUseCase.Run(id);
                return Ok(owner);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
