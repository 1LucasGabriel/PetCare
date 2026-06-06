using Microsoft.AspNetCore.Mvc;
using Registration.Application.DTOs;
using Registration.Application.UseCases;

namespace Registration.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreatePetController : ControllerBase
    {
        private readonly CreatePetUseCase _createPetUseCase;

        public CreatePetController(CreatePetUseCase createPetUseCase)
        {
            _createPetUseCase = createPetUseCase;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreatePetDTO request)
        {
            try
            {
                Guid id = _createPetUseCase.Run(request);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
