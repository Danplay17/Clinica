using System.ComponentModel.DataAnnotations;

namespace ClinicaOptica.Application.DTOs
{
    /// <summary>
    /// DTO para el login de usuarios
    /// </summary>
    public class LoginDto
    {
        /// <summary>
        /// Nombre de usuario o email
        /// </summary>
        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Contraseña del usuario
        /// </summary>
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Password { get; set; } = string.Empty;
    }

    /// <summary>
    /// DTO para el registro de usuarios
    /// </summary>
    public class RegisterDto
    {
        /// <summary>
        /// Nombre de usuario
        /// </summary>
        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre de usuario debe tener entre 3 y 100 caracteres")]
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Contraseña del usuario
        /// </summary>
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [StringLength(255, MinimumLength = 8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres")]
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Confirmación de contraseña
        /// </summary>
        [Required(ErrorMessage = "La confirmación de contraseña es obligatoria")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmPassword { get; set; } = string.Empty;

        /// <summary>
        /// ID del rol asignado
        /// </summary>
        [Required(ErrorMessage = "El rol es obligatorio")]
        public int RolId { get; set; }
    }

    /// <summary>
    /// DTO para la respuesta de autenticación
    /// </summary>
    public class AuthResponseDto
    {
        /// <summary>
        /// Token JWT
        /// </summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// Fecha de expiración del token
        /// </summary>
        public DateTime Expiration { get; set; }

        /// <summary>
        /// Datos del usuario autenticado
        /// </summary>
        public UsuarioDto Usuario { get; set; } = new();
    }

    /// <summary>
    /// DTO para los datos del usuario
    /// </summary>
    public class UsuarioDto
    {
        /// <summary>
        /// ID del usuario
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre de usuario
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// ID del rol
        /// </summary>
        public int RolId { get; set; }

        /// <summary>
        /// Nombre del rol
        /// </summary>
        public string RolNombre { get; set; } = string.Empty;

        /// <summary>
        /// Datos del optometrista si aplica
        /// </summary>
        public OptometristaDto? Optometrista { get; set; }
    }
} 