using Appointment.Application.DTOs;
using Appointment.Application.DTOs.Response;
using Appointment.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly CreateAppointmentUseCase _createAppointmentUseCase;
        private readonly GetAllAppointmentsUseCase _getAllAppointmentsUseCase;
        private readonly GetAppointmentUseCase _getAppointmentUseCase;
        private readonly GetAppointmentByVeterinarianUseCase _getAppointmentsByVeterinarianUseCase;
        private readonly GetAppointmentByPetUseCase _getAppointmentsByPetUseCase;
        private readonly GetAppointmentsByOwnerUseCase _getAppointmentsByOwnerUseCase;
        private readonly StartAppointmentUseCase _startAppointmentUseCase;
        private readonly CompleteAppointmentUseCase _completeAppointmentUseCase;
        private readonly CancelAppointmentUseCase _cancelAppointmentUseCase;
        private readonly DeleteAppointmentUseCase _deleteAppointmentUseCase;

        public AppointmentController(
            CreateAppointmentUseCase createAppointmentUseCase,
            GetAllAppointmentsUseCase getAllAppointmentsUseCase,
            GetAppointmentUseCase getAppointmentUseCase,
            GetAppointmentByVeterinarianUseCase getAppointmentsByVeterinarianUseCase,
            GetAppointmentByPetUseCase getAppointmentsByPetUseCase,
            GetAppointmentsByOwnerUseCase getAppointmentsByOwnerUseCase,
            StartAppointmentUseCase startAppointmentUseCase,
            CompleteAppointmentUseCase completeAppointmentUseCase,
            CancelAppointmentUseCase cancelAppointmentUseCase,
            DeleteAppointmentUseCase deleteAppointmentUseCase)
        {
            _createAppointmentUseCase = createAppointmentUseCase;
            _getAllAppointmentsUseCase = getAllAppointmentsUseCase;
            _getAppointmentUseCase = getAppointmentUseCase;
            _getAppointmentsByVeterinarianUseCase = getAppointmentsByVeterinarianUseCase;
            _getAppointmentsByPetUseCase = getAppointmentsByPetUseCase;
            _getAppointmentsByOwnerUseCase = getAppointmentsByOwnerUseCase;
            _startAppointmentUseCase = startAppointmentUseCase;
            _completeAppointmentUseCase = completeAppointmentUseCase;
            _cancelAppointmentUseCase = cancelAppointmentUseCase;
            _deleteAppointmentUseCase = deleteAppointmentUseCase;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateAppointmentDTO request)
        {
            try
            {
                Guid id = _createAppointmentUseCase.Run(request);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<AppointmentResponseDTO> appointments = _getAllAppointmentsUseCase.Run();
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                AppointmentResponseDTO appointment = _getAppointmentUseCase.Run(id);
                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("veterinarian/{veterinarianId}")]
        public IActionResult GetByVeterinarian(Guid veterinarianId)
        {
            try
            {
                List<AppointmentResponseDTO> appointments = _getAppointmentsByVeterinarianUseCase.Run(veterinarianId);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("pet/{petId}")]
        public IActionResult GetByPet(Guid petId)
        {
            try
            {
                List<AppointmentResponseDTO> appointments = _getAppointmentsByPetUseCase.Run(petId);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("owner/{ownerId}")]
        public IActionResult GetByOwner(Guid ownerId)
        {
            try
            {
                List<AppointmentResponseDTO> appointments = _getAppointmentsByOwnerUseCase.Run(ownerId);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/start")]
        public IActionResult Start(Guid id)
        {
            try
            {
                _startAppointmentUseCase.Run(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/complete")]
        public IActionResult Complete(Guid id)
        {
            try
            {
                _completeAppointmentUseCase.Run(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/cancel")]
        public IActionResult Cancel(Guid id, [FromBody] CancelAppointmentDTO request)
        {
            try
            {
                _cancelAppointmentUseCase.Run(id, request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _deleteAppointmentUseCase.Run(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}