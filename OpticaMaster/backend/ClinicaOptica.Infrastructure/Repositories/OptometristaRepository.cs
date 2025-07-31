using Microsoft.EntityFrameworkCore;
using ClinicaOptica.Domain.ClasesOptica;
using ClinicaOptica.Application.Interfaces;

namespace ClinicaOptica.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio para la gestión de optometristas
    /// </summary>
    public class OptometristaRepository : IOptometristaRepository
    {
        private readonly OpticaDbContext _context;

        public OptometristaRepository(OpticaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todos los optometristas
        /// </summary>
        public async Task<IEnumerable<Optometrista>> GetAllAsync()
        {
            return await _context.Optometristas
                .Include(o => o.Usuario)
                .OrderBy(o => o.Nombre)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene un optometrista por ID
        /// </summary>
        public async Task<Optometrista?> GetByIdAsync(int id)
        {
            return await _context.Optometristas
                .Include(o => o.Usuario)
                .Include(o => o.Consultas)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        /// <summary>
        /// Busca optometristas por nombre
        /// </summary>
        public async Task<IEnumerable<Optometrista>> SearchByNameAsync(string nombre)
        {
            return await _context.Optometristas
                .Include(o => o.Usuario)
                .Where(o => o.Nombre.Contains(nombre))
                .OrderBy(o => o.Nombre)
                .ToListAsync();
        }

        /// <summary>
        /// Busca optometristas por cédula profesional
        /// </summary>
        public async Task<Optometrista?> GetByCedulaAsync(string cedula)
        {
            return await _context.Optometristas
                .Include(o => o.Usuario)
                .FirstOrDefaultAsync(o => o.CedulaProfesional == cedula);
        }

        /// <summary>
        /// Crea un nuevo optometrista
        /// </summary>
        public async Task<Optometrista> CreateAsync(Optometrista optometrista)
        {
            _context.Optometristas.Add(optometrista);
            await _context.SaveChangesAsync();
            return optometrista;
        }

        /// <summary>
        /// Actualiza un optometrista existente
        /// </summary>
        public async Task<Optometrista> UpdateAsync(Optometrista optometrista)
        {
            _context.Optometristas.Update(optometrista);
            await _context.SaveChangesAsync();
            return optometrista;
        }

        /// <summary>
        /// Elimina un optometrista
        /// </summary>
        public async Task<bool> DeleteAsync(int id)
        {
            var optometrista = await _context.Optometristas.FindAsync(id);
            if (optometrista == null)
                return false;

            _context.Optometristas.Remove(optometrista);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Verifica si existe un optometrista con la cédula especificada
        /// </summary>
        public async Task<bool> ExistsByCedulaAsync(string cedula, int? excludeId = null)
        {
            var query = _context.Optometristas.Where(o => o.CedulaProfesional == cedula);
            
            if (excludeId.HasValue)
                query = query.Where(o => o.Id != excludeId.Value);

            return await query.AnyAsync();
        }

        /// <summary>
        /// Verifica si existe un optometrista con el correo especificado
        /// </summary>
        public async Task<bool> ExistsByCorreoAsync(string correo, int? excludeId = null)
        {
            var query = _context.Optometristas.Where(o => o.Correo == correo);
            
            if (excludeId.HasValue)
                query = query.Where(o => o.Id != excludeId.Value);

            return await query.AnyAsync();
        }
    }
} 