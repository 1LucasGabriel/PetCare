using Appointment.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetAllMedicalRecordController : ControllerBase
    {
        private readonly GetAllMedicalRecordUseCase _getAllMedicalRecordUseCase;
        public GetAllMedicalRecordController(GetAllMedicalRecordUseCase getAllMedicalRecordUseCase)
        {
            _getAllMedicalRecordUseCase = getAllMedicalRecordUseCase;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var medicalRecords = _getAllMedicalRecordUseCase.Run();
                return Ok(medicalRecords);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
