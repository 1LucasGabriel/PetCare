using Appointment.Application.DTOs;
using Appointment.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginVeterinarianController : ControllerBase
    {
        private readonly LoginVeterinarianUseCase _loginVeterinarianUseCase;

        public LoginVeterinarianController(LoginVeterinarianUseCase loginVeterinarianUseCase)
        {
            _loginVeterinarianUseCase = loginVeterinarianUseCase;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginDTO request)
        {
            try
            {
                var response = _loginVeterinarianUseCase.Run(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
