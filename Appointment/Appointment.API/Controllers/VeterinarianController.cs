using Appointment.Application.DTOs;
using Appointment.Application.DTOs.Response;
using Appointment.Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Appointment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VeterinarianController : ControllerBase
    {
        private readonly CreateVeterinarianUseCase _createVeterinarianUseCase;
        private readonly GetVeterinarianUseCase _getVeterinarianUseCase;
        private readonly GetAllVeterinariansUseCase _getAllVeterinariansUseCase;
        private readonly UpdateVeterinarianUseCase _updateVeterinarianUseCase;
        private readonly DeleteVeterinarianUseCase _deleteVeterinarianUseCase;
        private readonly LoginVeterinarianUseCase _loginVeterinarianUseCase;

        public VeterinarianController(
            CreateVeterinarianUseCase createVeterinarianUseCase,
            GetVeterinarianUseCase getVeterinarianUseCase,
            GetAllVeterinariansUseCase getAllVeterinariansUseCase,
            UpdateVeterinarianUseCase updateVeterinarianUseCase,
            DeleteVeterinarianUseCase deleteVeterinarianUseCase,
            LoginVeterinarianUseCase loginVeterinarianUseCase)
        {
            _createVeterinarianUseCase = createVeterinarianUseCase;
            _getVeterinarianUseCase = getVeterinarianUseCase;
            _getAllVeterinariansUseCase = getAllVeterinariansUseCase;
            _updateVeterinarianUseCase = updateVeterinarianUseCase;
            _deleteVeterinarianUseCase = deleteVeterinarianUseCase;
            _loginVeterinarianUseCase = loginVeterinarianUseCase;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateVeterinarianDTO request)
        {
            try
            {
                Guid id = _createVeterinarianUseCase.Run(request);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
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

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<VeterinarianResponseDTO> vets = _getAllVeterinariansUseCase.Run();
                return Ok(vets);
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
                VeterinarianResponseDTO vet = _getVeterinarianUseCase.Run(id);
                return Ok(vet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] UpdateVeterinarianDTO request)
        {
            try
            {
                _updateVeterinarianUseCase.Run(id, request);
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
                _deleteVeterinarianUseCase.Run(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
