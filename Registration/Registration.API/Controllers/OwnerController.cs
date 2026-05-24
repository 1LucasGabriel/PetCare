using Microsoft.AspNetCore.Mvc;
using Registration.Application.DTOs;
using Registration.Application.DTOs.Response;
using Registration.Application.UseCases;

namespace Registration.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OwnerController : ControllerBase
    {
        private readonly CreateOwnerUseCase _createOwnerUseCase;
        private readonly GetAllOwnerUseCase _getAllOwnerUseCase;
        private readonly GetOwnerUseCase _getOwnerUseCase;
        private readonly UpdateOwnerUseCase _updateOwnerUseCase;
        private readonly DeleteOwnerUseCase _deleteOwnerUseCase;
        public OwnerController(CreateOwnerUseCase createOwnerUseCase, GetAllOwnerUseCase getAllOwnerUseCase, GetOwnerUseCase getOwnerUseCase, UpdateOwnerUseCase updateOwnerUseCase, DeleteOwnerUseCase deleteOwnerUseCase)
        {
            _createOwnerUseCase = createOwnerUseCase;
            _getAllOwnerUseCase = getAllOwnerUseCase;
            _getOwnerUseCase = getOwnerUseCase;
            _updateOwnerUseCase = updateOwnerUseCase;
            _deleteOwnerUseCase = deleteOwnerUseCase;
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

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<OwnerResponseDTO> owners = _getAllOwnerUseCase.Run();
                return Ok(owners);
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
                OwnerResponseDTO owner = _getOwnerUseCase.Run(id);
                return Ok(owner);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _deleteOwnerUseCase.Run(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
