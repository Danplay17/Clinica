using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ClinicaOptica.Application.Interfaces;
using ClinicaOptica.Application.DTOs;

namespace ClinicaOptica.Api.Controllers
{
    /// <summary>
    /// Controlador para la gestión de consultas
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ConsultasController : ControllerBase
    {
        private readonly IConsultaService _consultaService;

        public ConsultasController(IConsultaService consultaService)
        {
            _consultaService = consultaService;
        }

        /// <summary>
        /// Obtiene todas las consultas
        /// </summary>
        /// <returns>Lista de consultas</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ConsultaDto>), 200)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var consultas = await _consultaService.GetAllAsync();
                return Ok(consultas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene una consulta por ID
        /// </summary>
        /// <param name="id">ID de la consulta</param>
        /// <returns>Consulta encontrada</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ConsultaDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var consulta = await _consultaService.GetByIdAsync(id);
                if (consulta == null)
                    return NotFound(new { message = "Consulta no encontrada" });

                return Ok(consulta);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Crea una nueva consulta
        /// </summary>
        /// <param name="createConsultaDto">Datos de la consulta a crear</param>
        /// <returns>Consulta creada</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ConsultaDto), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] CreateConsultaDto createConsultaDto)
        {
            try
            {
                var consulta = await _consultaService.CreateAsync(createConsultaDto);
                return CreatedAtAction(nameof(GetById), new { id = consulta.Id }, consulta);
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
        /// Actualiza una consulta existente
        /// </summary>
        /// <param name="id">ID de la consulta</param>
        /// <param name="updateConsultaDto">Datos actualizados</param>
        /// <returns>Consulta actualizada</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ConsultaDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateConsultaDto updateConsultaDto)
        {
            try
            {
                var consulta = await _consultaService.UpdateAsync(id, updateConsultaDto);
                return Ok(consulta);
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
        /// Elimina una consulta
        /// </summary>
        /// <param name="id">ID de la consulta a eliminar</param>
        /// <returns>True si se eliminó correctamente</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _consultaService.DeleteAsync(id);
                return Ok(new { success = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene las consultas de un paciente
        /// </summary>
        /// <param name="pacienteId">ID del paciente</param>
        /// <returns>Lista de consultas</returns>
        [HttpGet("paciente/{pacienteId}")]
        [ProducesResponseType(typeof(IEnumerable<ConsultaDto>), 200)]
        public async Task<IActionResult> GetByPaciente(int pacienteId)
        {
            try
            {
                var consultas = await _consultaService.GetByPacienteAsync(pacienteId);
                return Ok(consultas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene las consultas de un optometrista
        /// </summary>
        /// <param name="optometristaId">ID del optometrista</param>
        /// <returns>Lista de consultas</returns>
        [HttpGet("optometrista/{optometristaId}")]
        [ProducesResponseType(typeof(IEnumerable<ConsultaDto>), 200)]
        public async Task<IActionResult> GetByOptometrista(int optometristaId)
        {
            try
            {
                var consultas = await _consultaService.GetByOptometristaAsync(optometristaId);
                return Ok(consultas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene las consultas por rango de fechas
        /// </summary>
        /// <param name="fechaDesde">Fecha desde</param>
        /// <param name="fechaHasta">Fecha hasta</param>
        /// <returns>Lista de consultas</returns>
        [HttpGet("fecha-range")]
        [ProducesResponseType(typeof(IEnumerable<ConsultaDto>), 200)]
        public async Task<IActionResult> GetByFechaRange([FromQuery] DateTime fechaDesde, [FromQuery] DateTime fechaHasta)
        {
            try
            {
                var consultas = await _consultaService.GetByFechaRangeAsync(fechaDesde, fechaHasta);
                return Ok(consultas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
} 