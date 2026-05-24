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
        public OwnerController(CreateOwnerUseCase createOwnerUseCase, GetAllOwnerUseCase getAllOwnerUseCase)
        {
            _createOwnerUseCase = createOwnerUseCase;
            _getAllOwnerUseCase = getAllOwnerUseCase;
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
    }
}
