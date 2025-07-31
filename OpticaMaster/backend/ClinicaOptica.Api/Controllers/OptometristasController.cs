using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ClinicaOptica.Application.Interfaces;
using ClinicaOptica.Application.DTOs;

namespace ClinicaOptica.Api.Controllers
{
    /// <summary>
    /// Controlador para la gestión de optometristas
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OptometristasController : ControllerBase
    {
        private readonly IOptometristaService _optometristaService;

        public OptometristasController(IOptometristaService optometristaService)
        {
            _optometristaService = optometristaService;
        }

        /// <summary>
        /// Obtiene todos los optometristas
        /// </summary>
        /// <returns>Lista de optometristas</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OptometristaDto>), 200)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var optometristas = await _optometristaService.GetAllAsync();
                return Ok(optometristas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene un optometrista por ID
        /// </summary>
        /// <param name="id">ID del optometrista</param>
        /// <returns>Optometrista encontrado</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OptometristaDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var optometrista = await _optometristaService.GetByIdAsync(id);
                if (optometrista == null)
                    return NotFound(new { message = "Optometrista no encontrado" });

                return Ok(optometrista);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Crea un nuevo optometrista
        /// </summary>
        /// <param name="createOptometristaDto">Datos del optometrista a crear</param>
        /// <returns>Optometrista creado</returns>
        [HttpPost]
        [ProducesResponseType(typeof(OptometristaDto), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] CreateOptometristaDto createOptometristaDto)
        {
            try
            {
                var optometrista = await _optometristaService.CreateAsync(createOptometristaDto);
                return CreatedAtAction(nameof(GetById), new { id = optometrista.Id }, optometrista);
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
        /// Actualiza un optometrista existente
        /// </summary>
        /// <param name="id">ID del optometrista</param>
        /// <param name="updateOptometristaDto">Datos actualizados</param>
        /// <returns>Optometrista actualizado</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(OptometristaDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateOptometristaDto updateOptometristaDto)
        {
            try
            {
                var optometrista = await _optometristaService.UpdateAsync(id, updateOptometristaDto);
                return Ok(optometrista);
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
        /// Elimina un optometrista
        /// </summary>
        /// <param name="id">ID del optometrista a eliminar</param>
        /// <returns>True si se eliminó correctamente</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _optometristaService.DeleteAsync(id);
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
        /// Obtiene las consultas de un optometrista
        /// </summary>
        /// <param name="id">ID del optometrista</param>
        /// <returns>Lista de consultas</returns>
        [HttpGet("{id}/consultas")]
        [ProducesResponseType(typeof(IEnumerable<ConsultaDto>), 200)]
        public async Task<IActionResult> GetConsultas(int id)
        {
            try
            {
                var consultas = await _optometristaService.GetConsultasAsync(id);
                return Ok(consultas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene las citas de un optometrista
        /// </summary>
        /// <param name="id">ID del optometrista</param>
        /// <returns>Lista de citas</returns>
        [HttpGet("{id}/citas")]
        [ProducesResponseType(typeof(IEnumerable<CitaDto>), 200)]
        public async Task<IActionResult> GetCitas(int id)
        {
            try
            {
                var citas = await _optometristaService.GetCitasAsync(id);
                return Ok(citas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
} 