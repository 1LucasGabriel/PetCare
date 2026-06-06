using Microsoft.AspNetCore.Mvc;
using Registration.Application.DTOs.Response;
using Registration.Application.UseCases;
using System.Collections.Generic;

namespace Registration.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetAllOwnerController : ControllerBase
    {
        private readonly GetAllOwnerUseCase _getAllOwnerUseCase;

        public GetAllOwnerController(GetAllOwnerUseCase getAllOwnerUseCase)
        {
            _getAllOwnerUseCase = getAllOwnerUseCase;
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
