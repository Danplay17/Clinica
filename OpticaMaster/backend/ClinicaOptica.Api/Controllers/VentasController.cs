using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ClinicaOptica.Application.Interfaces;
using ClinicaOptica.Application.DTOs;

namespace ClinicaOptica.Api.Controllers
{
    /// <summary>
    /// Controlador para la gestión de ventas
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class VentasController : ControllerBase
    {
        private readonly IVentaService _ventaService;

        public VentasController(IVentaService ventaService)
        {
            _ventaService = ventaService;
        }

        /// <summary>
        /// Obtiene todas las ventas
        /// </summary>
        /// <returns>Lista de ventas</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<VentaDto>), 200)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var ventas = await _ventaService.GetAllAsync();
                return Ok(ventas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene una venta por ID
        /// </summary>
        /// <param name="id">ID de la venta</param>
        /// <returns>Venta encontrada</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(VentaDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var venta = await _ventaService.GetByIdAsync(id);
                if (venta == null)
                    return NotFound(new { message = "Venta no encontrada" });

                return Ok(venta);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Crea una nueva venta
        /// </summary>
        /// <param name="createVentaDto">Datos de la venta a crear</param>
        /// <returns>Venta creada</returns>
        [HttpPost]
        [ProducesResponseType(typeof(VentaDto), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] CreateVentaDto createVentaDto)
        {
            try
            {
                var venta = await _ventaService.CreateAsync(createVentaDto);
                return CreatedAtAction(nameof(GetById), new { id = venta.Id }, venta);
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
        /// Actualiza una venta existente
        /// </summary>
        /// <param name="id">ID de la venta</param>
        /// <param name="updateVentaDto">Datos actualizados</param>
        /// <returns>Venta actualizada</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(VentaDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateVentaDto updateVentaDto)
        {
            try
            {
                var venta = await _ventaService.UpdateAsync(id, updateVentaDto);
                return Ok(venta);
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
        /// Elimina una venta
        /// </summary>
        /// <param name="id">ID de la venta a eliminar</param>
        /// <returns>True si se eliminó correctamente</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _ventaService.DeleteAsync(id);
                return Ok(new { success = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene las ventas de un paciente
        /// </summary>
        /// <param name="pacienteId">ID del paciente</param>
        /// <returns>Lista de ventas</returns>
        [HttpGet("paciente/{pacienteId}")]
        [ProducesResponseType(typeof(IEnumerable<VentaDto>), 200)]
        public async Task<IActionResult> GetByPaciente(int pacienteId)
        {
            try
            {
                var ventas = await _ventaService.GetByPacienteAsync(pacienteId);
                return Ok(ventas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene las ventas por rango de fechas
        /// </summary>
        /// <param name="fechaDesde">Fecha desde</param>
        /// <param name="fechaHasta">Fecha hasta</param>
        /// <returns>Lista de ventas</returns>
        [HttpGet("fecha-range")]
        [ProducesResponseType(typeof(IEnumerable<VentaDto>), 200)]
        public async Task<IActionResult> GetByFechaRange([FromQuery] DateTime fechaDesde, [FromQuery] DateTime fechaHasta)
        {
            try
            {
                var ventas = await _ventaService.GetByFechaRangeAsync(fechaDesde, fechaHasta);
                return Ok(ventas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene el total de ventas por período
        /// </summary>
        /// <param name="fechaDesde">Fecha desde</param>
        /// <param name="fechaHasta">Fecha hasta</param>
        /// <returns>Total de ventas</returns>
        [HttpGet("total")]
        [ProducesResponseType(typeof(decimal), 200)]
        public async Task<IActionResult> GetTotalVentas([FromQuery] DateTime fechaDesde, [FromQuery] DateTime fechaHasta)
        {
            try
            {
                var total = await _ventaService.GetTotalVentasAsync(fechaDesde, fechaHasta);
                return Ok(new { total });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene estadísticas de ventas
        /// </summary>
        /// <param name="fechaDesde">Fecha desde</param>
        /// <param name="fechaHasta">Fecha hasta</param>
        /// <returns>Estadísticas de ventas</returns>
        [HttpGet("estadisticas")]
        [ProducesResponseType(typeof(VentasEstadisticasDto), 200)]
        public async Task<IActionResult> GetEstadisticas([FromQuery] DateTime fechaDesde, [FromQuery] DateTime fechaHasta)
        {
            try
            {
                var estadisticas = await _ventaService.GetEstadisticasAsync(fechaDesde, fechaHasta);
                return Ok(estadisticas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
} 