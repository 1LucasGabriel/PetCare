using Appointment.Application.DTOs.Response;
using Appointment.Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Appointment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetAllVeterinarianController : ControllerBase
    {
        private readonly GetAllVeterinariansUseCase _getAllVeterinariansUseCase;

        public GetAllVeterinarianController(GetAllVeterinariansUseCase getAllVeterinariansUseCase)
        {
            _getAllVeterinariansUseCase = getAllVeterinariansUseCase;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<VeterinarianResponseDTO> vets = _getAllVeterinariansUseCase.Run();
                return Ok(vets);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
