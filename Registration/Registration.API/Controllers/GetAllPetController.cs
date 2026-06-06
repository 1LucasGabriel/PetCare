using Microsoft.AspNetCore.Mvc;
using Registration.Application.DTOs.Response;
using Registration.Application.UseCases;
using System.Collections.Generic;

namespace Registration.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetAllPetController : ControllerBase
    {
        private readonly GetAllPetsUseCase _getAllPetsUseCase;

        public GetAllPetController(GetAllPetsUseCase getAllPetsUseCase)
        {
            _getAllPetsUseCase = getAllPetsUseCase;
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
    }
}
