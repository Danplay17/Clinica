using Microsoft.EntityFrameworkCore;
using ClinicaOptica.Domain.ClasesOptica;
using ClinicaOptica.Application.Interfaces;

namespace ClinicaOptica.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio para la gestión de citas
    /// </summary>
    public class CitaRepository : ICitaRepository
    {
        private readonly OpticaDbContext _context;

        public CitaRepository(OpticaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todas las citas
        /// </summary>
        public async Task<IEnumerable<Cita>> GetAllAsync()
        {
            return await _context.Citas
                .Include(c => c.Paciente)
                .Include(c => c.Optometrista)
                .OrderBy(c => c.Fecha)
                .ThenBy(c => c.Hora)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene una cita por ID
        /// </summary>
        public async Task<Cita?> GetByIdAsync(int id)
        {
            return await _context.Citas
                .Include(c => c.Paciente)
                .Include(c => c.Optometrista)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        /// <summary>
        /// Crea una nueva cita
        /// </summary>
        public async Task<Cita> CreateAsync(Cita cita)
        {
            _context.Citas.Add(cita);
            await _context.SaveChangesAsync();
            return cita;
        }

        /// <summary>
        /// Actualiza una cita existente
        /// </summary>
        public async Task<Cita> UpdateAsync(Cita cita)
        {
            _context.Citas.Update(cita);
            await _context.SaveChangesAsync();
            return cita;
        }

        /// <summary>
        /// Elimina una cita
        /// </summary>
        public async Task<bool> DeleteAsync(int id)
        {
            var cita = await _context.Citas.FindAsync(id);
            if (cita == null)
                return false;

            _context.Citas.Remove(cita);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Obtiene las citas de un paciente
        /// </summary>
        public async Task<IEnumerable<Cita>> GetByPacienteAsync(int pacienteId)
        {
            return await _context.Citas
                .Include(c => c.Paciente)
                .Include(c => c.Optometrista)
                .Where(c => c.PacienteId == pacienteId)
                .OrderBy(c => c.Fecha)
                .ThenBy(c => c.Hora)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene las citas de un optometrista
        /// </summary>
        public async Task<IEnumerable<Cita>> GetByOptometristaAsync(int optometristaId)
        {
            return await _context.Citas
                .Include(c => c.Paciente)
                .Include(c => c.Optometrista)
                .Where(c => c.OptometristaId == optometristaId)
                .OrderBy(c => c.Fecha)
                .ThenBy(c => c.Hora)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene las citas por fecha
        /// </summary>
        public async Task<IEnumerable<Cita>> GetByFechaAsync(DateTime fecha)
        {
            return await _context.Citas
                .Include(c => c.Paciente)
                .Include(c => c.Optometrista)
                .Where(c => c.Fecha.Date == fecha.Date)
                .OrderBy(c => c.Hora)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene las citas por rango de fechas
        /// </summary>
        public async Task<IEnumerable<Cita>> GetByFechaRangeAsync(DateTime fechaDesde, DateTime fechaHasta)
        {
            return await _context.Citas
                .Include(c => c.Paciente)
                .Include(c => c.Optometrista)
                .Where(c => c.Fecha >= fechaDesde && c.Fecha <= fechaHasta)
                .OrderBy(c => c.Fecha)
                .ThenBy(c => c.Hora)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene las citas por estado
        /// </summary>
        public async Task<IEnumerable<Cita>> GetByEstadoAsync(string estado)
        {
            return await _context.Citas
                .Include(c => c.Paciente)
                .Include(c => c.Optometrista)
                .Where(c => c.Estado == estado)
                .OrderBy(c => c.Fecha)
                .ThenBy(c => c.Hora)
                .ToListAsync();
        }

        /// <summary>
        /// Verifica disponibilidad de horario
        /// </summary>
        public async Task<bool> VerificarDisponibilidadAsync(int optometristaId, DateTime fecha, TimeSpan hora, int duracion, int? excludeCitaId = null)
        {
            var horaFin = hora.Add(TimeSpan.FromMinutes(duracion));
            
            var query = _context.Citas
                .Where(c => c.OptometristaId == optometristaId && 
                           c.Fecha.Date == fecha.Date &&
                           c.Estado != "Cancelada");

            if (excludeCitaId.HasValue)
                query = query.Where(c => c.Id != excludeCitaId.Value);

            var citasExistentes = await query.ToListAsync();

            foreach (var cita in citasExistentes)
            {
                var citaHoraFin = cita.Hora.Add(TimeSpan.FromMinutes(cita.Duracion));
                
                // Verificar si hay solapamiento
                if (hora < citaHoraFin && horaFin > cita.Hora)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Obtiene las citas del día para un optometrista
        /// </summary>
        public async Task<IEnumerable<Cita>> GetCitasDelDiaAsync(int optometristaId, DateTime fecha)
        {
            return await _context.Citas
                .Include(c => c.Paciente)
                .Include(c => c.Optometrista)
                .Where(c => c.OptometristaId == optometristaId && 
                           c.Fecha.Date == fecha.Date &&
                           c.Estado != "Cancelada")
                .OrderBy(c => c.Hora)
                .ToListAsync();
        }
    }
} 