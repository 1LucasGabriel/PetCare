using Appointment.Application.DTOs;
using Appointment.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreateVeterinarianController : ControllerBase
    {
        private readonly CreateVeterinarianUseCase _createVeterinarianUseCase;

        public CreateVeterinarianController(CreateVeterinarianUseCase createVeterinarianUseCase)
        {
            _createVeterinarianUseCase = createVeterinarianUseCase;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateVeterinarianDTO request)
        {
            try
            {
                Guid id = _createVeterinarianUseCase.Run(request);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
