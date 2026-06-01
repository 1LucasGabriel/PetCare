using Appointment.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeleteMedicalRecordController : ControllerBase
    {
        private readonly DeleteMedicalRecordUseCase _deleteMedicalRecordUseCase;
        public DeleteMedicalRecordController(DeleteMedicalRecordUseCase deleteMedicalRecordUseCase)
        {
            _deleteMedicalRecordUseCase = deleteMedicalRecordUseCase;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _deleteMedicalRecordUseCase.Run(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
