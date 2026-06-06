using Microsoft.AspNetCore.Mvc;
using Registration.Application.DTOs.Response;
using Registration.Application.UseCases;

namespace Registration.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetPetController : ControllerBase
    {
        private readonly GetPetUseCase _getPetUseCase;

        public GetPetController(GetPetUseCase getPetUseCase)
        {
            _getPetUseCase = getPetUseCase;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                PetResponseDTO pet = _getPetUseCase.Run(id);
                return Ok(pet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
