using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ClinicaOptica.Application.Interfaces;
using ClinicaOptica.Application.DTOs;

namespace ClinicaOptica.Api.Controllers
{
    /// <summary>
    /// Controlador para la gestión de pacientes
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public PacientesController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        /// <summary>
        /// Obtiene todos los pacientes
        /// </summary>
        /// <returns>Lista de pacientes</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PacienteDto>), 200)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var pacientes = await _pacienteService.GetAllAsync();
                return Ok(pacientes);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene un paciente por ID
        /// </summary>
        /// <param name="id">ID del paciente</param>
        /// <returns>Paciente encontrado</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PacienteDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var paciente = await _pacienteService.GetByIdAsync(id);
                if (paciente == null)
                    return NotFound(new { message = "Paciente no encontrado" });

                return Ok(paciente);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Busca pacientes por nombre
        /// </summary>
        /// <param name="nombre">Nombre a buscar</param>
        /// <returns>Lista de pacientes que coinciden</returns>
        [HttpGet("search/name")]
        [ProducesResponseType(typeof(IEnumerable<PacienteDto>), 200)]
        public async Task<IActionResult> SearchByName([FromQuery] string nombre)
        {
            try
            {
                var pacientes = await _pacienteService.SearchByNameAsync(nombre);
                return Ok(pacientes);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Busca pacientes por teléfono
        /// </summary>
        /// <param name="telefono">Teléfono a buscar</param>
        /// <returns>Lista de pacientes que coinciden</returns>
        [HttpGet("search/phone")]
        [ProducesResponseType(typeof(IEnumerable<PacienteDto>), 200)]
        public async Task<IActionResult> SearchByPhone([FromQuery] string telefono)
        {
            try
            {
                var pacientes = await _pacienteService.SearchByPhoneAsync(telefono);
                return Ok(pacientes);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Crea un nuevo paciente
        /// </summary>
        /// <param name="createPacienteDto">Datos del paciente a crear</param>
        /// <returns>Paciente creado</returns>
        [HttpPost]
        [ProducesResponseType(typeof(PacienteDto), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] CreatePacienteDto createPacienteDto)
        {
            try
            {
                var paciente = await _pacienteService.CreateAsync(createPacienteDto);
                return CreatedAtAction(nameof(GetById), new { id = paciente.Id }, paciente);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Actualiza un paciente existente
        /// </summary>
        /// <param name="id">ID del paciente</param>
        /// <param name="updatePacienteDto">Datos actualizados</param>
        /// <returns>Paciente actualizado</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PacienteDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePacienteDto updatePacienteDto)
        {
            try
            {
                var paciente = await _pacienteService.UpdateAsync(id, updatePacienteDto);
                return Ok(paciente);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un paciente
        /// </summary>
        /// <param name="id">ID del paciente a eliminar</param>
        /// <returns>True si se eliminó correctamente</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _pacienteService.DeleteAsync(id);
                return Ok(new { success = result });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene el historial de consultas de un paciente
        /// </summary>
        /// <param name="id">ID del paciente</param>
        /// <returns>Lista de consultas</returns>
        [HttpGet("{id}/consultas")]
        [ProducesResponseType(typeof(IEnumerable<ConsultaDto>), 200)]
        public async Task<IActionResult> GetConsultas(int id)
        {
            try
            {
                var consultas = await _pacienteService.GetConsultasAsync(id);
                return Ok(consultas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene el historial de ventas de un paciente
        /// </summary>
        /// <param name="id">ID del paciente</param>
        /// <returns>Lista de ventas</returns>
        [HttpGet("{id}/ventas")]
        [ProducesResponseType(typeof(IEnumerable<VentaDto>), 200)]
        public async Task<IActionResult> GetVentas(int id)
        {
            try
            {
                var ventas = await _pacienteService.GetVentasAsync(id);
                return Ok(ventas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
} 