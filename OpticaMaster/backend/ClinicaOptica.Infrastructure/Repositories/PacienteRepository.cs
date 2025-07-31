using Microsoft.EntityFrameworkCore;
using ClinicaOptica.Domain.ClasesOptica;
using ClinicaOptica.Application.Interfaces;

namespace ClinicaOptica.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio para la gestión de pacientes
    /// </summary>
    public class PacienteRepository : IPacienteRepository
    {
        private readonly OpticaDbContext _context;

        public PacienteRepository(OpticaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todos los pacientes
        /// </summary>
        public async Task<IEnumerable<Paciente>> GetAllAsync()
        {
            return await _context.Pacientes
                .Include(p => p.Tutor)
                .OrderBy(p => p.Nombre)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene un paciente por ID
        /// </summary>
        public async Task<Paciente?> GetByIdAsync(int id)
        {
            return await _context.Pacientes
                .Include(p => p.Tutor)
                .Include(p => p.Consultas)
                .Include(p => p.Ventas)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// Busca pacientes por nombre
        /// </summary>
        public async Task<IEnumerable<Paciente>> SearchByNameAsync(string nombre)
        {
            return await _context.Pacientes
                .Include(p => p.Tutor)
                .Where(p => p.Nombre.Contains(nombre))
                .OrderBy(p => p.Nombre)
                .ToListAsync();
        }

        /// <summary>
        /// Busca pacientes por teléfono
        /// </summary>
        public async Task<IEnumerable<Paciente>> SearchByPhoneAsync(string telefono)
        {
            return await _context.Pacientes
                .Include(p => p.Tutor)
                .Where(p => p.Telefono.Contains(telefono))
                .OrderBy(p => p.Nombre)
                .ToListAsync();
        }

        /// <summary>
        /// Crea un nuevo paciente
        /// </summary>
        public async Task<Paciente> CreateAsync(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
            return paciente;
        }

        /// <summary>
        /// Actualiza un paciente existente
        /// </summary>
        public async Task<Paciente> UpdateAsync(Paciente paciente)
        {
            _context.Pacientes.Update(paciente);
            await _context.SaveChangesAsync();
            return paciente;
        }

        /// <summary>
        /// Elimina un paciente
        /// </summary>
        public async Task<bool> DeleteAsync(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
                return false;

            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Verifica si existe un paciente con el email especificado
        /// </summary>
        public async Task<bool> ExistsByEmailAsync(string email, int? excludeId = null)
        {
            var query = _context.Pacientes.Where(p => p.Email == email);
            
            if (excludeId.HasValue)
                query = query.Where(p => p.Id != excludeId.Value);

            return await query.AnyAsync();
        }
    }
} 