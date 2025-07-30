using System.ComponentModel.DataAnnotations;
using ClinicaOptica.Domain.ValueObjects;

namespace ClinicaOptica.Domain.ClasesOptica
{
    /// <summary>
    /// Representa un permiso específico en el sistema.
    /// Los permisos se asignan a roles para controlar el acceso a funcionalidades.
    /// </summary>
    public class Permiso : BaseEntity
    {
        /// <summary>
        /// Nombre del permiso.
        /// Ejemplo: "CrearPaciente", "EliminarVenta", "VerReportes".
        /// </summary>
        [Required(ErrorMessage = "El nombre del permiso es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Descripción detallada del permiso.
        /// </summary>
        [StringLength(255)]
        public string? Descripcion { get; set; }

        // Propiedades de navegación

        /// <summary>
        /// Lista de roles que tienen asignado este permiso.
        /// Relación muchos a muchos.
        /// </summary>
        public virtual ICollection<Rol> Roles { get; set; } = new List<Rol>();
    }
}