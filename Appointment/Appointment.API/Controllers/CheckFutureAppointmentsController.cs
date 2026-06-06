using Appointment.Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Appointment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckFutureAppointmentsController : ControllerBase
    {
        private readonly CheckFutureAppointmentsUseCase _checkUseCase;

        public CheckFutureAppointmentsController(CheckFutureAppointmentsUseCase checkUseCase)
        {
            _checkUseCase = checkUseCase;
        }

        [HttpGet("{petId}")]
        public async Task<IActionResult> HasFutureAppointments(Guid petId)
        {
            var has = await _checkUseCase.ExecuteAsync(petId);
            return has ? Ok() : NotFound();
        }
    }
}
