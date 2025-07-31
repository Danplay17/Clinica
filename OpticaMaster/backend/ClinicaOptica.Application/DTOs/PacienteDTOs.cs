using System.ComponentModel.DataAnnotations;

namespace ClinicaOptica.Application.DTOs
{
    /// <summary>
    /// DTO para mostrar datos de un paciente
    /// </summary>
    public class PacienteDto
    {
        /// <summary>
        /// ID del paciente
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre completo del paciente
        /// </summary>
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Género del paciente
        /// </summary>
        public string Genero { get; set; } = string.Empty;

        /// <summary>
        /// Edad del paciente
        /// </summary>
        public int Edad { get; set; }

        /// <summary>
        /// Correo electrónico del paciente
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Teléfono del paciente
        /// </summary>
        public string Telefono { get; set; } = string.Empty;

        /// <summary>
        /// Fecha de creación del registro
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Datos del tutor si es menor de edad
        /// </summary>
        public TutorDto? Tutor { get; set; }
    }

    /// <summary>
    /// DTO para crear un nuevo paciente
    /// </summary>
    public class CreatePacienteDto
    {
        /// <summary>
        /// Nombre completo del paciente
        /// </summary>
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Género del paciente
        /// </summary>
        [Required(ErrorMessage = "El género es obligatorio")]
        public string Genero { get; set; } = string.Empty;

        /// <summary>
        /// Edad del paciente
        /// </summary>
        [Required(ErrorMessage = "La edad es obligatoria")]
        [Range(0, 120, ErrorMessage = "La edad debe estar entre 0 y 120 años")]
        public int Edad { get; set; }

        /// <summary>
        /// Estado civil del paciente
        /// </summary>
        [Required(ErrorMessage = "El estado civil es obligatorio")]
        public string EstadoCivil { get; set; } = string.Empty;

        /// <summary>
        /// Escolaridad del paciente
        /// </summary>
        [Required(ErrorMessage = "La escolaridad es obligatoria")]
        public string Escolaridad { get; set; } = string.Empty;

        /// <summary>
        /// Ocupación del paciente
        /// </summary>
        [Required(ErrorMessage = "La ocupación es obligatoria")]
        [StringLength(100, ErrorMessage = "La ocupación no puede exceder 100 caracteres")]
        public string Ocupacion { get; set; } = string.Empty;

        /// <summary>
        /// Domicilio del paciente
        /// </summary>
        [Required(ErrorMessage = "El domicilio es obligatorio")]
        [StringLength(200, ErrorMessage = "El domicilio no puede exceder 200 caracteres")]
        public string Domicilio { get; set; } = string.Empty;

        /// <summary>
        /// Correo electrónico del paciente
        /// </summary>
        [EmailAddress(ErrorMessage = "Ingrese un correo electrónico válido")]
        public string? Email { get; set; }

        /// <summary>
        /// Teléfono del paciente
        /// </summary>
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [RegularExpression(@"^[\d\s\-\+\(\)]{10,15}$", ErrorMessage = "Ingrese un número de teléfono válido")]
        public string Telefono { get; set; } = string.Empty;

        /// <summary>
        /// Datos del tutor si es menor de edad
        /// </summary>
        public CreateTutorDto? Tutor { get; set; }
    }

    /// <summary>
    /// DTO para actualizar un paciente
    /// </summary>
    public class UpdatePacienteDto
    {
        /// <summary>
        /// Nombre completo del paciente
        /// </summary>
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Género del paciente
        /// </summary>
        [Required(ErrorMessage = "El género es obligatorio")]
        public string Genero { get; set; } = string.Empty;

        /// <summary>
        /// Edad del paciente
        /// </summary>
        [Required(ErrorMessage = "La edad es obligatoria")]
        [Range(0, 120, ErrorMessage = "La edad debe estar entre 0 y 120 años")]
        public int Edad { get; set; }

        /// <summary>
        /// Estado civil del paciente
        /// </summary>
        [Required(ErrorMessage = "El estado civil es obligatorio")]
        public string EstadoCivil { get; set; } = string.Empty;

        /// <summary>
        /// Escolaridad del paciente
        /// </summary>
        [Required(ErrorMessage = "La escolaridad es obligatoria")]
        public string Escolaridad { get; set; } = string.Empty;

        /// <summary>
        /// Ocupación del paciente
        /// </summary>
        [Required(ErrorMessage = "La ocupación es obligatoria")]
        [StringLength(100, ErrorMessage = "La ocupación no puede exceder 100 caracteres")]
        public string Ocupacion { get; set; } = string.Empty;

        /// <summary>
        /// Domicilio del paciente
        /// </summary>
        [Required(ErrorMessage = "El domicilio es obligatorio")]
        [StringLength(200, ErrorMessage = "El domicilio no puede exceder 200 caracteres")]
        public string Domicilio { get; set; } = string.Empty;

        /// <summary>
        /// Correo electrónico del paciente
        /// </summary>
        [EmailAddress(ErrorMessage = "Ingrese un correo electrónico válido")]
        public string? Email { get; set; }

        /// <summary>
        /// Teléfono del paciente
        /// </summary>
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [RegularExpression(@"^[\d\s\-\+\(\)]{10,15}$", ErrorMessage = "Ingrese un número de teléfono válido")]
        public string Telefono { get; set; } = string.Empty;
    }
} 