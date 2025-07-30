using System.ComponentModel.DataAnnotations;

namespace ClinicaOptica.Domain.ClasesOptica
{
    /// <summary>
    /// Representa a un usuario del sistema (administrador u optometrista).
    /// Los usuarios tienen credenciales de acceso y un rol específico que define sus permisos.
    /// El administrador es quien crea usuarios para optometristas y gestiona sus contraseñas.
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Identificador único del usuario.
        /// Clave primaria autogenerada.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre de usuario para iniciar sesión (generalmente correo electrónico).
        /// Debe ser único en el sistema.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Contraseña encriptada del usuario.
        /// Se almacena como hash por seguridad.
        /// Solo el administrador puede modificar contraseñas.
        /// </summary>
        [Required]
        [StringLength(255)]
        public string PasswordHash { get; set; } = string.Empty;

        /// <summary>
        /// Identificador del rol asignado al usuario.
        /// Clave foránea hacia la tabla Roles.
        /// </summary>
        [Required]
        public int RolId { get; set; }

        // Propiedades de navegación

        /// <summary>
        /// Rol asignado a este usuario.
        /// Propiedad de navegación hacia la entidad Rol.
        /// </summary>
        public virtual Rol? Rol { get; set; }

        /// <summary>
        /// Información del optometrista asociado a este usuario.
        /// Solo aplica si el usuario tiene rol de optometrista.
        /// Relación uno a uno opcional.
        /// </summary>
        public virtual Optometrista? Optometrista { get; set; }
    }
}