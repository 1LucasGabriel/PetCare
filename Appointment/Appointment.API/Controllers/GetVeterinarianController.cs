using Appointment.Application.DTOs.Response;
using Appointment.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetVeterinarianController : ControllerBase
    {
        private readonly GetVeterinarianUseCase _getVeterinarianUseCase;

        public GetVeterinarianController(GetVeterinarianUseCase getVeterinarianUseCase)
        {
            _getVeterinarianUseCase = getVeterinarianUseCase;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                VeterinarianResponseDTO vet = _getVeterinarianUseCase.Run(id);
                return Ok(vet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
