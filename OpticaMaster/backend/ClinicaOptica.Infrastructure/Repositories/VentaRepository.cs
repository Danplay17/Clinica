using Microsoft.EntityFrameworkCore;
using ClinicaOptica.Domain.ClasesOptica;
using ClinicaOptica.Application.Interfaces;

namespace ClinicaOptica.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio para la gestión de ventas
    /// </summary>
    public class VentaRepository : IVentaRepository
    {
        private readonly OpticaDbContext _context;

        public VentaRepository(OpticaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todas las ventas
        /// </summary>
        public async Task<IEnumerable<Venta>> GetAllAsync()
        {
            return await _context.Ventas
                .Include(v => v.Paciente)
                .Include(v => v.Producto)
                .OrderByDescending(v => v.Fecha)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene una venta por ID
        /// </summary>
        public async Task<Venta?> GetByIdAsync(int id)
        {
            return await _context.Ventas
                .Include(v => v.Paciente)
                .Include(v => v.Producto)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        /// <summary>
        /// Crea una nueva venta
        /// </summary>
        public async Task<Venta> CreateAsync(Venta venta)
        {
            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();
            return venta;
        }

        /// <summary>
        /// Actualiza una venta existente
        /// </summary>
        public async Task<Venta> UpdateAsync(Venta venta)
        {
            _context.Ventas.Update(venta);
            await _context.SaveChangesAsync();
            return venta;
        }

        /// <summary>
        /// Elimina una venta
        /// </summary>
        public async Task<bool> DeleteAsync(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
                return false;

            _context.Ventas.Remove(venta);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Obtiene las ventas de un paciente
        /// </summary>
        public async Task<IEnumerable<Venta>> GetByPacienteAsync(int pacienteId)
        {
            return await _context.Ventas
                .Include(v => v.Paciente)
                .Include(v => v.Producto)
                .Where(v => v.PacienteId == pacienteId)
                .OrderByDescending(v => v.Fecha)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene las ventas por rango de fechas
        /// </summary>
        public async Task<IEnumerable<Venta>> GetByFechaRangeAsync(DateTime fechaDesde, DateTime fechaHasta)
        {
            return await _context.Ventas
                .Include(v => v.Paciente)
                .Include(v => v.Producto)
                .Where(v => v.Fecha >= fechaDesde && v.Fecha <= fechaHasta)
                .OrderByDescending(v => v.Fecha)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene el total de ventas por período
        /// </summary>
        public async Task<decimal> GetTotalVentasAsync(DateTime fechaDesde, DateTime fechaHasta)
        {
            return await _context.Ventas
                .Where(v => v.Fecha >= fechaDesde && v.Fecha <= fechaHasta)
                .SumAsync(v => v.Cantidad * v.Producto.Precio);
        }

        /// <summary>
        /// Obtiene estadísticas de ventas por día
        /// </summary>
        public async Task<IEnumerable<object>> GetEstadisticasPorDiaAsync(DateTime fechaDesde, DateTime fechaHasta)
        {
            return await _context.Ventas
                .Where(v => v.Fecha >= fechaDesde && v.Fecha <= fechaHasta)
                .GroupBy(v => v.Fecha.Date)
                .Select(g => new
                {
                    Fecha = g.Key,
                    Total = g.Sum(v => v.Cantidad * v.Producto.Precio),
                    NumeroTransacciones = g.Count()
                })
                .OrderBy(x => x.Fecha)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene estadísticas de ventas por producto
        /// </summary>
        public async Task<IEnumerable<object>> GetEstadisticasPorProductoAsync(DateTime fechaDesde, DateTime fechaHasta)
        {
            return await _context.Ventas
                .Where(v => v.Fecha >= fechaDesde && v.Fecha <= fechaHasta)
                .GroupBy(v => new { v.ProductoId, v.Producto.Nombre })
                .Select(g => new
                {
                    ProductoId = g.Key.ProductoId,
                    ProductoNombre = g.Key.Nombre,
                    Cantidad = g.Sum(v => v.Cantidad),
                    Total = g.Sum(v => v.Cantidad * v.Producto.Precio)
                })
                .OrderByDescending(x => x.Total)
                .ToListAsync();
        }
    }
} 