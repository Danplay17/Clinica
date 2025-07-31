using System.ComponentModel.DataAnnotations;

namespace ClinicaOptica.Application.DTOs
{
    /// <summary>
    /// DTO para crear un nuevo optometrista
    /// </summary>
    public class CreateOptometristaDto
    {
        /// <summary>
        /// Nombre completo del optometrista
        /// </summary>
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Cédula profesional
        /// </summary>
        [Required(ErrorMessage = "La cédula profesional es obligatoria")]
        [RegularExpression(@"^\d{6,10}$", ErrorMessage = "La cédula profesional debe tener entre 6 y 10 dígitos")]
        public string CedulaProfesional { get; set; } = string.Empty;

        /// <summary>
        /// Especialidad del optometrista
        /// </summary>
        [Required(ErrorMessage = "La especialidad es obligatoria")]
        [StringLength(100, ErrorMessage = "La especialidad no puede exceder 100 caracteres")]
        public string Especialidad { get; set; } = string.Empty;

        /// <summary>
        /// Correo electrónico
        /// </summary>
        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "Ingrese un correo electrónico válido")]
        public string Correo { get; set; } = string.Empty;

        /// <summary>
        /// Teléfono
        /// </summary>
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [RegularExpression(@"^[\d\s\-\+\(\)]{10,15}$", ErrorMessage = "Ingrese un número de teléfono válido")]
        public string Telefono { get; set; } = string.Empty;

        /// <summary>
        /// ID del usuario asociado
        /// </summary>
        [Required(ErrorMessage = "El usuario es obligatorio")]
        public int UsuarioId { get; set; }
    }

    /// <summary>
    /// DTO para actualizar un optometrista
    /// </summary>
    public class UpdateOptometristaDto
    {
        /// <summary>
        /// Nombre completo del optometrista
        /// </summary>
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Cédula profesional
        /// </summary>
        [Required(ErrorMessage = "La cédula profesional es obligatoria")]
        [RegularExpression(@"^\d{6,10}$", ErrorMessage = "La cédula profesional debe tener entre 6 y 10 dígitos")]
        public string CedulaProfesional { get; set; } = string.Empty;

        /// <summary>
        /// Especialidad del optometrista
        /// </summary>
        [Required(ErrorMessage = "La especialidad es obligatoria")]
        [StringLength(100, ErrorMessage = "La especialidad no puede exceder 100 caracteres")]
        public string Especialidad { get; set; } = string.Empty;

        /// <summary>
        /// Correo electrónico
        /// </summary>
        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "Ingrese un correo electrónico válido")]
        public string Correo { get; set; } = string.Empty;

        /// <summary>
        /// Teléfono
        /// </summary>
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [RegularExpression(@"^[\d\s\-\+\(\)]{10,15}$", ErrorMessage = "Ingrese un número de teléfono válido")]
        public string Telefono { get; set; } = string.Empty;
    }
} 