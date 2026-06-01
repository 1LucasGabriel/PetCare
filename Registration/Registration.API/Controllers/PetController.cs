using Microsoft.AspNetCore.Mvc;
using Registration.Application.DTOs;
using Registration.Application.DTOs.Response;
using Registration.Application.UseCases;

namespace Registration.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetController : ControllerBase
    {
        private readonly CreatePetUseCase _createPetUseCase;
        private readonly GetAllPetsUseCase _getAllPetsUseCase;
        private readonly GetPetUseCase _getPetUseCase;
        private readonly UpdatePetUseCase _updatePetUseCase;
        private readonly DeletePetUseCase _deletePetUseCase;
        public PetController(CreatePetUseCase createPetUseCase, GetAllPetsUseCase getAllPetsUseCase, GetPetUseCase getPetUseCase, UpdatePetUseCase updatePetUseCase, DeletePetUseCase deletePetUseCase)
        {
            _createPetUseCase = createPetUseCase;
            _getAllPetsUseCase = getAllPetsUseCase;
            _getPetUseCase = getPetUseCase;
            _updatePetUseCase = updatePetUseCase;
            _deletePetUseCase = deletePetUseCase;
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

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<PetResponseDTO> pets = _getAllPetsUseCase.Run();
                return Ok(pets);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _deletePetUseCase.Run(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
