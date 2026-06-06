using Microsoft.AspNetCore.Mvc;
using Registration.Application.DTOs;
using Registration.Application.UseCases;

namespace Registration.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginOwnerController : ControllerBase
    {
        private readonly LoginOwnerUseCase _loginOwnerUseCase;

        public LoginOwnerController(LoginOwnerUseCase loginOwnerUseCase)
        {
            _loginOwnerUseCase = loginOwnerUseCase;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginDTO request)
        {
            try
            {
                var response = _loginOwnerUseCase.Run(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
