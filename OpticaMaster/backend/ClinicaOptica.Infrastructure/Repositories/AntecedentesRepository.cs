using Microsoft.EntityFrameworkCore;
using ClinicaOptica.Application.Interfaces;
using ClinicaOptica.Domain.ClasesOptica;

namespace ClinicaOptica.Infrastructure.Repositories
{
    /// <summary>
    /// Implementación del repositorio para antecedentes clínicos.
    /// </summary>
    public class AntecedentesRepository : IAntecedentesRepository
    {
        private readonly OpticaDbContext _context;

        public AntecedentesRepository(OpticaDbContext context)
        {
            _context = context;
        }

        public async Task<Antecedentes?> GetByConsultaIdAsync(int consultaId)
        {
            return await _context.Antecedentes
                .FirstOrDefaultAsync(a => a.ConsultaId == consultaId);
        }

        public async Task<Antecedentes> CreateAsync(Antecedentes antecedentes)
        {
            _context.Antecedentes.Add(antecedentes);
            await _context.SaveChangesAsync();
            return antecedentes;
        }

        public async Task<Antecedentes> UpdateAsync(Antecedentes antecedentes)
        {
            _context.Antecedentes.Update(antecedentes);
            await _context.SaveChangesAsync();
            return antecedentes;
        }

        public async Task DeleteAsync(int id)
        {
            var antecedentes = await _context.Antecedentes.FindAsync(id);
            if (antecedentes != null)
            {
                _context.Antecedentes.Remove(antecedentes);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsByConsultaIdAsync(int consultaId)
        {
            return await _context.Antecedentes
                .AnyAsync(a => a.ConsultaId == consultaId);
        }
    }
} 