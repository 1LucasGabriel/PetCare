using Microsoft.AspNetCore.Mvc;
using Registration.Application.UseCases;
using System.Threading.Tasks;

namespace Registration.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeletePetController : ControllerBase
    {
        private readonly DeletePetUseCase _deletePetUseCase;

        public DeletePetController(DeletePetUseCase deletePetUseCase)
        {
            _deletePetUseCase = deletePetUseCase;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _deletePetUseCase.Run(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
