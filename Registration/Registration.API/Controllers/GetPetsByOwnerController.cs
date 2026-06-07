using Microsoft.AspNetCore.Mvc;
using Registration.Application.DTOs.Response;
using Registration.Application.UseCases;
using System;
using System.Collections.Generic;

namespace Registration.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetPetsByOwnerController : ControllerBase
    {
        private readonly GetPetsByOwnerUseCase _getPetsByOwnerUseCase;

        public GetPetsByOwnerController(GetPetsByOwnerUseCase getPetsByOwnerUseCase)
        {
            _getPetsByOwnerUseCase = getPetsByOwnerUseCase;
        }

        [HttpGet("{ownerId}")]
        public IActionResult Get(Guid ownerId)
        {
            try
            {
                List<PetResponseDTO> pets = _getPetsByOwnerUseCase.Run(ownerId);
                return Ok(pets);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
