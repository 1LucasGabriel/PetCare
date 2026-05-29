using Appointment.Application.DTOs;
using Appointment.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UpdateMedicalRecordController : ControllerBase
    {
        private readonly UpdateMedicalRecordUseCase _updateMedicalRecordUseCase;

        public UpdateMedicalRecordController(UpdateMedicalRecordUseCase updateMedicalRecordUseCase)
        {
            _updateMedicalRecordUseCase = updateMedicalRecordUseCase;
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateMedicalRecordDTO request)
        {
            try
            {
                _updateMedicalRecordUseCase.Run(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
