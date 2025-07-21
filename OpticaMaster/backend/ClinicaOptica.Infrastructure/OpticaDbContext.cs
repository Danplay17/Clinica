using Microsoft.EntityFrameworkCore;
using ClinicaOptica.Domain; // Asegúrate de tener tus modelos aquí

namespace ClinicaOptica.Infrastructure
{
    public class OpticaDbContext : DbContext
    {
        public OpticaDbContext(DbContextOptions<OpticaDbContext> options) : base(options) { }

        public DbSet<Paciente> Pacientes { get; set; }
        // Agrega aquí los DbSet para tus otras entidades
    }
}
