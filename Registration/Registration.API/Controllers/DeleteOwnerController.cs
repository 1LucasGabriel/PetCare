using Microsoft.AspNetCore.Mvc;
using Registration.Application.UseCases;

namespace Registration.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeleteOwnerController : ControllerBase
    {
        private readonly DeleteOwnerUseCase _deleteOwnerUseCase;

        public DeleteOwnerController(DeleteOwnerUseCase deleteOwnerUseCase)
        {
            _deleteOwnerUseCase = deleteOwnerUseCase;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _deleteOwnerUseCase.Run(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
