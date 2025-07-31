using Microsoft.EntityFrameworkCore;
using ClinicaOptica.Domain.ClasesOptica;
using ClinicaOptica.Application.Interfaces;

namespace ClinicaOptica.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio para la gestión de productos
    /// </summary>
    public class ProductoRepository : IProductoRepository
    {
        private readonly OpticaDbContext _context;

        public ProductoRepository(OpticaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todos los productos
        /// </summary>
        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            return await _context.Productos
                .OrderBy(p => p.Nombre)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene un producto por ID
        /// </summary>
        public async Task<Producto?> GetByIdAsync(int id)
        {
            return await _context.Productos
                .Include(p => p.Ventas)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// Busca productos por nombre
        /// </summary>
        public async Task<IEnumerable<Producto>> SearchByNameAsync(string nombre)
        {
            return await _context.Productos
                .Where(p => p.Nombre.Contains(nombre))
                .OrderBy(p => p.Nombre)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene productos por tipo
        /// </summary>
        public async Task<IEnumerable<Producto>> GetByTipoAsync(string tipo)
        {
            return await _context.Productos
                .Where(p => p.Tipo == tipo)
                .OrderBy(p => p.Nombre)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene productos con stock bajo
        /// </summary>
        public async Task<IEnumerable<Producto>> GetStockBajoAsync(int stockMinimo)
        {
            return await _context.Productos
                .Where(p => p.Stock <= stockMinimo && p.Activo)
                .OrderBy(p => p.Stock)
                .ToListAsync();
        }

        /// <summary>
        /// Crea un nuevo producto
        /// </summary>
        public async Task<Producto> CreateAsync(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        /// <summary>
        /// Actualiza un producto existente
        /// </summary>
        public async Task<Producto> UpdateAsync(Producto producto)
        {
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        /// <summary>
        /// Elimina un producto
        /// </summary>
        public async Task<bool> DeleteAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
                return false;

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Actualiza el stock de un producto
        /// </summary>
        public async Task<Producto> UpdateStockAsync(int id, int cantidad)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
                throw new ArgumentException("Producto no encontrado");

            producto.Stock += cantidad;
            if (producto.Stock < 0)
                producto.Stock = 0;

            await _context.SaveChangesAsync();
            return producto;
        }
    }
} 