using Microsoft.AspNetCore.Mvc;
using Registration.Application.DTOs;
using Registration.Application.UseCases;

namespace Registration.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreateOwnerController : ControllerBase
    {
        private readonly CreateOwnerUseCase _createOwnerUseCase;

        public CreateOwnerController(CreateOwnerUseCase createOwnerUseCase)
        {
            _createOwnerUseCase = createOwnerUseCase;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateOwnerDTO request)
        {
            try
            {
                Guid id = _createOwnerUseCase.Run(request);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
