using Microsoft.EntityFrameworkCore;
using ClinicaOptica.Domain.ClasesOptica;

namespace ClinicaOptica.Infrastructure
{
    /// <summary>
    /// Contexto de base de datos para la aplicación de óptica.
    /// Gestiona todas las entidades del dominio y sus relaciones.
    /// </summary>
    public class OpticaDbContext : DbContext
    {
        /// <summary>
        /// Inicializa una nueva instancia del contexto de base de datos.
        /// </summary>
        /// <param name="options">Opciones de configuración del contexto.</param>
        public OpticaDbContext(DbContextOptions<OpticaDbContext> options) : base(options) 
        {
        }

        // DbSets para las entidades que SÍ existen
        
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<Optometrista> Optometristas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Diagnostico> Diagnosticos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }  // ← Corregido: Venta (no Ventas)
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Notificacion> Notificaciones { get; set; }
        public DbSet<LogActividad> LogsActividad { get; set; }
        
        // Secciones de la hoja clínica
        public DbSet<Antecedentes> Antecedentes { get; set; }
        public DbSet<AgudezaVisual> AgudezaVisual { get; set; }
        public DbSet<Lensometria> Lensometria { get; set; }
        public DbSet<Refraccion> Refraccion { get; set; }
        public DbSet<RecetaFinal> RecetaFinal { get; set; }

        /// <summary>
        /// Configura el modelo de datos y las relaciones entre entidades.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar relaciones básicas

            // Usuario -> Rol (muchos a uno)
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.RolId)
                .OnDelete(DeleteBehavior.Restrict);

            // Usuario -> Optometrista (uno a uno)
            modelBuilder.Entity<Optometrista>()
                .HasOne(o => o.Usuario)
                .WithOne(u => u.Optometrista)
                .HasForeignKey<Optometrista>(o => o.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configurar índices únicos
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<Optometrista>()
                .HasIndex(o => o.CedulaProfesional)
                .IsUnique();

            modelBuilder.Entity<Optometrista>()
                .HasIndex(o => o.Correo)
                .IsUnique();

            // Configurar precisión para decimales
            modelBuilder.Entity<Producto>()
                .Property(p => p.Precio)
                .HasPrecision(10, 2);

            // Configurar nombres de tablas
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Rol>().ToTable("Roles");
            modelBuilder.Entity<Permiso>().ToTable("Permisos");
            modelBuilder.Entity<Optometrista>().ToTable("Optometristas");
            modelBuilder.Entity<Paciente>().ToTable("Pacientes");
            modelBuilder.Entity<Consulta>().ToTable("Consultas");
            modelBuilder.Entity<Diagnostico>().ToTable("Diagnosticos");
            modelBuilder.Entity<Producto>().ToTable("Productos");
            modelBuilder.Entity<Venta>().ToTable("Ventas");
            modelBuilder.Entity<Cita>().ToTable("Citas");
            modelBuilder.Entity<Notificacion>().ToTable("Notificaciones");
            modelBuilder.Entity<LogActividad>().ToTable("LogsActividad");
            
            // Configurar tablas de secciones clínicas
            modelBuilder.Entity<Antecedentes>().ToTable("Antecedentes");
            modelBuilder.Entity<AgudezaVisual>().ToTable("AgudezaVisual");
            modelBuilder.Entity<Lensometria>().ToTable("Lensometria");
            modelBuilder.Entity<Refraccion>().ToTable("Refraccion");
            modelBuilder.Entity<RecetaFinal>().ToTable("RecetaFinal");
        }
    }
}
