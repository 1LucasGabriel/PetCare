using Appointment.Application.UseCases;
using Appointment.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreateMedicalRecordController : ControllerBase
    {
        private readonly CreateMedicalRecordUseCase _createMedicalRecordUseCase;

        public CreateMedicalRecordController(CreateMedicalRecordUseCase createMedicalRecordUseCase)
        {
            _createMedicalRecordUseCase = createMedicalRecordUseCase;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateMedicalRecordDTO request)
        {
            try
            {
                Guid id = _createMedicalRecordUseCase.Run(request);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
