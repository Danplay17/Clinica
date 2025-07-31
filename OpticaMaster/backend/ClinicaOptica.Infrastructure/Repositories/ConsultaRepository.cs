using Microsoft.EntityFrameworkCore;
using ClinicaOptica.Domain.ClasesOptica;
using ClinicaOptica.Application.Interfaces;

namespace ClinicaOptica.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio para la gestión de consultas
    /// </summary>
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly OpticaDbContext _context;

        public ConsultaRepository(OpticaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todas las consultas
        /// </summary>
        public async Task<IEnumerable<Consulta>> GetAllAsync()
        {
            return await _context.Consultas
                .Include(c => c.Paciente)
                .Include(c => c.Optometrista)
                .Include(c => c.Diagnostico)
                .OrderByDescending(c => c.Fecha)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene una consulta por ID
        /// </summary>
        public async Task<Consulta?> GetByIdAsync(int id)
        {
            return await _context.Consultas
                .Include(c => c.Paciente)
                .Include(c => c.Optometrista)
                .Include(c => c.Diagnostico)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        /// <summary>
        /// Crea una nueva consulta
        /// </summary>
        public async Task<Consulta> CreateAsync(Consulta consulta)
        {
            _context.Consultas.Add(consulta);
            await _context.SaveChangesAsync();
            return consulta;
        }

        /// <summary>
        /// Actualiza una consulta existente
        /// </summary>
        public async Task<Consulta> UpdateAsync(Consulta consulta)
        {
            _context.Consultas.Update(consulta);
            await _context.SaveChangesAsync();
            return consulta;
        }

        /// <summary>
        /// Elimina una consulta
        /// </summary>
        public async Task<bool> DeleteAsync(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);
            if (consulta == null)
                return false;

            _context.Consultas.Remove(consulta);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Obtiene las consultas de un paciente
        /// </summary>
        public async Task<IEnumerable<Consulta>> GetByPacienteAsync(int pacienteId)
        {
            return await _context.Consultas
                .Include(c => c.Paciente)
                .Include(c => c.Optometrista)
                .Include(c => c.Diagnostico)
                .Where(c => c.PacienteId == pacienteId)
                .OrderByDescending(c => c.Fecha)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene las consultas de un optometrista
        /// </summary>
        public async Task<IEnumerable<Consulta>> GetByOptometristaAsync(int optometristaId)
        {
            return await _context.Consultas
                .Include(c => c.Paciente)
                .Include(c => c.Optometrista)
                .Include(c => c.Diagnostico)
                .Where(c => c.OptometristaId == optometristaId)
                .OrderByDescending(c => c.Fecha)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene las consultas por rango de fechas
        /// </summary>
        public async Task<IEnumerable<Consulta>> GetByFechaRangeAsync(DateTime fechaDesde, DateTime fechaHasta)
        {
            return await _context.Consultas
                .Include(c => c.Paciente)
                .Include(c => c.Optometrista)
                .Include(c => c.Diagnostico)
                .Where(c => c.Fecha >= fechaDesde && c.Fecha <= fechaHasta)
                .OrderByDescending(c => c.Fecha)
                .ToListAsync();
        }
    }
} 