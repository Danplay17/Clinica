using System.ComponentModel.DataAnnotations;
using ClinicaOptica.Domain.ValueObjects;

namespace ClinicaOptica.Domain.ClasesOptica
{
    /// <summary>
    /// Define los roles disponibles en el sistema.
    /// Tipos: Administrador (gestión completa), Optometrista (funciones clínicas).
    /// Cada rol determina los permisos y funcionalidades disponibles.
    /// </summary>
    public class Rol : BaseEntity
    {
        /// <summary>
        /// Nombre descriptivo del rol.
        /// Valores: "Administrador", "Optometrista".
        /// Debe ser único en el sistema.
        /// </summary>
        [Required(ErrorMessage = "El nombre del rol es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre del rol no puede exceder 50 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        // Propiedades de navegación

        /// <summary>
        /// Lista de usuarios que tienen asignado este rol.
        /// Propiedad de navegación hacia Usuario.
        /// Relación uno a muchos.
        /// </summary>
        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

        /// <summary>
        /// Lista de permisos asociados a este rol.
        /// Propiedad de navegación hacia Permiso.
        /// Relación muchos a muchos.
        /// </summary>
        public virtual ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();
    }
}