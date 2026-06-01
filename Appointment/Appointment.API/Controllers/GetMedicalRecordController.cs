using Appointment.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetMedicalRecordController : ControllerBase
    {
        private readonly GetMedicalRecordUseCase _getMedicalRecordUseCase;
        public GetMedicalRecordController(GetMedicalRecordUseCase getMedicalRecordUseCase)
        {
            _getMedicalRecordUseCase = getMedicalRecordUseCase;
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var medicalRecord = _getMedicalRecordUseCase.Run(id);
                return Ok(medicalRecord);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
