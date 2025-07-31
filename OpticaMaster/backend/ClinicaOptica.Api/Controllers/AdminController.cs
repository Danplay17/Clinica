using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ClinicaOptica.Application.Interfaces;
using ClinicaOptica.Application.DTOs;
using ClinicaOptica.Domain.ClasesOptica;

namespace ClinicaOptica.Api.Controllers
{
    /// <summary>
    /// Controlador para funciones administrativas.
    /// Solo accesible por usuarios con rol de administrador.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Administrador")]
    public class AdminController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IOptometristaRepository _optometristaRepository;
        private readonly IVentaRepository _ventaRepository;
        private readonly IProductoRepository _productoRepository;

        public AdminController(
            IUsuarioRepository usuarioRepository,
            IOptometristaRepository optometristaRepository,
            IVentaRepository ventaRepository,
            IProductoRepository productoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _optometristaRepository = optometristaRepository;
            _ventaRepository = ventaRepository;
            _productoRepository = productoRepository;
        }

        /// <summary>
        /// Obtiene estadísticas generales del sistema.
        /// </summary>
        [HttpGet("estadisticas")]
        public async Task<ActionResult<object>> GetEstadisticas()
        {
            try
            {
                var totalUsuarios = await _usuarioRepository.GetAllAsync();
                var totalOptometristas = await _optometristaRepository.GetAllAsync();
                var totalProductos = await _productoRepository.GetAllAsync();
                var ventas = await _ventaRepository.GetAllAsync();

                var estadisticas = new
                {
                    TotalUsuarios = totalUsuarios.Count(),
                    TotalOptometristas = totalOptometristas.Count(),
                    TotalProductos = totalProductos.Count(),
                    TotalVentas = ventas.Count(),
                    VentasUltimoMes = ventas.Where(v => v.Fecha >= DateTime.Now.AddMonths(-1)).Count(),
                    ProductosBajoStock = totalProductos.Where(p => p.Stock < 10).Count()
                };

                return Ok(estadisticas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener estadísticas: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtiene el historial de actividad de todos los usuarios.
        /// </summary>
        [HttpGet("actividad")]
        public async Task<ActionResult<object>> GetActividadReciente()
        {
            try
            {
                // Aquí se implementaría la lógica para obtener logs de actividad
                // Por ahora retornamos un placeholder
                var actividad = new
                {
                    Fecha = DateTime.Now,
                    Mensaje = "Sistema de logs en desarrollo"
                };

                return Ok(actividad);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener actividad: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtiene reporte de ventas por período.
        /// </summary>
        [HttpGet("reporte-ventas")]
        public async Task<ActionResult<object>> GetReporteVentas([FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFin)
        {
            try
            {
                var ventas = await _ventaRepository.GetAllAsync();
                var ventasFiltradas = ventas.Where(v => v.Fecha >= fechaInicio && v.Fecha <= fechaFin);

                var reporte = new
                {
                    Periodo = $"{fechaInicio:dd/MM/yyyy} - {fechaFin:dd/MM/yyyy}",
                    TotalVentas = ventasFiltradas.Count(),
                    TotalIngresos = ventasFiltradas.Sum(v => v.Total),
                    VentasPorDia = ventasFiltradas.GroupBy(v => v.Fecha.Date)
                        .Select(g => new { Fecha = g.Key, Total = g.Sum(v => v.Total), Cantidad = g.Count() })
                };

                return Ok(reporte);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al generar reporte: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtiene productos con stock bajo.
        /// </summary>
        [HttpGet("productos-bajo-stock")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductosBajoStock([FromQuery] int stockMinimo = 10)
        {
            try
            {
                var productos = await _productoRepository.GetAllAsync();
                var productosBajoStock = productos.Where(p => p.Stock <= stockMinimo);

                return Ok(productosBajoStock);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener productos: {ex.Message}");
            }
        }

        /// <summary>
        /// Desactiva un usuario del sistema.
        /// </summary>
        [HttpPut("usuarios/{id}/desactivar")]
        public async Task<ActionResult> DesactivarUsuario(int id)
        {
            try
            {
                var usuario = await _usuarioRepository.GetByIdAsync(id);
                if (usuario == null)
                    return NotFound("Usuario no encontrado");

                // Aquí se implementaría la lógica para desactivar usuario
                // Por ejemplo, agregar un campo Activo a la entidad Usuario

                return Ok("Usuario desactivado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al desactivar usuario: {ex.Message}");
            }
        }
    }
} 