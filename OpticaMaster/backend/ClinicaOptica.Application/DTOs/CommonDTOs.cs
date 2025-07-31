using System.ComponentModel.DataAnnotations;

namespace ClinicaOptica.Application.DTOs
{
    /// <summary>
    /// DTO para mostrar datos de un tutor
    /// </summary>
    public class TutorDto
    {
        /// <summary>
        /// ID del tutor
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre completo del tutor
        /// </summary>
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Género del tutor
        /// </summary>
        public string Genero { get; set; } = string.Empty;

        /// <summary>
        /// Edad del tutor
        /// </summary>
        public int Edad { get; set; }

        /// <summary>
        /// Ocupación del tutor
        /// </summary>
        public string Ocupacion { get; set; } = string.Empty;

        /// <summary>
        /// Domicilio del tutor
        /// </summary>
        public string Domicilio { get; set; } = string.Empty;

        /// <summary>
        /// Correo electrónico del tutor
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Teléfono del tutor
        /// </summary>
        public string Telefono { get; set; } = string.Empty;

        /// <summary>
        /// Relación con el paciente
        /// </summary>
        public string RelacionConPaciente { get; set; } = string.Empty;

        /// <summary>
        /// Indica si es el responsable legal
        /// </summary>
        public bool EsResponsableLegal { get; set; }
    }

    /// <summary>
    /// DTO para crear un nuevo tutor
    /// </summary>
    public class CreateTutorDto
    {
        /// <summary>
        /// Nombre completo del tutor
        /// </summary>
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Género del tutor
        /// </summary>
        [Required(ErrorMessage = "El género es obligatorio")]
        public string Genero { get; set; } = string.Empty;

        /// <summary>
        /// Edad del tutor
        /// </summary>
        [Required(ErrorMessage = "La edad es obligatoria")]
        [Range(18, 120, ErrorMessage = "La edad debe ser mayor a 18 años")]
        public int Edad { get; set; }

        /// <summary>
        /// Ocupación del tutor
        /// </summary>
        [Required(ErrorMessage = "La ocupación es obligatoria")]
        [StringLength(100, ErrorMessage = "La ocupación no puede exceder 100 caracteres")]
        public string Ocupacion { get; set; } = string.Empty;

        /// <summary>
        /// Domicilio del tutor
        /// </summary>
        [Required(ErrorMessage = "El domicilio es obligatorio")]
        [StringLength(200, ErrorMessage = "El domicilio no puede exceder 200 caracteres")]
        public string Domicilio { get; set; } = string.Empty;

        /// <summary>
        /// Correo electrónico del tutor
        /// </summary>
        [EmailAddress(ErrorMessage = "Ingrese un correo electrónico válido")]
        public string? Email { get; set; }

        /// <summary>
        /// Teléfono del tutor
        /// </summary>
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [RegularExpression(@"^[\d\s\-\+\(\)]{10,15}$", ErrorMessage = "Ingrese un número de teléfono válido")]
        public string Telefono { get; set; } = string.Empty;

        /// <summary>
        /// Relación con el paciente
        /// </summary>
        [Required(ErrorMessage = "La relación con el paciente es obligatoria")]
        public string RelacionConPaciente { get; set; } = string.Empty;

        /// <summary>
        /// Indica si es el responsable legal
        /// </summary>
        [Required(ErrorMessage = "Debe confirmar si es el responsable legal")]
        public bool EsResponsableLegal { get; set; }
    }

    /// <summary>
    /// DTO para mostrar datos de un optometrista
    /// </summary>
    public class OptometristaDto
    {
        /// <summary>
        /// ID del optometrista
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre completo del optometrista
        /// </summary>
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Cédula profesional
        /// </summary>
        public string CedulaProfesional { get; set; } = string.Empty;

        /// <summary>
        /// Especialidad del optometrista
        /// </summary>
        public string Especialidad { get; set; } = string.Empty;

        /// <summary>
        /// Correo electrónico
        /// </summary>
        public string Correo { get; set; } = string.Empty;

        /// <summary>
        /// Teléfono
        /// </summary>
        public string Telefono { get; set; } = string.Empty;
    }

    /// <summary>
    /// DTO para mostrar datos de una consulta
    /// </summary>
    public class ConsultaDto
    {
        /// <summary>
        /// ID de la consulta
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID del paciente
        /// </summary>
        public int PacienteId { get; set; }

        /// <summary>
        /// Nombre del paciente
        /// </summary>
        public string PacienteNombre { get; set; } = string.Empty;

        /// <summary>
        /// ID del optometrista
        /// </summary>
        public int OptometristaId { get; set; }

        /// <summary>
        /// Nombre del optometrista
        /// </summary>
        public string OptometristaNombre { get; set; } = string.Empty;

        /// <summary>
        /// Fecha de la consulta
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Observaciones de la consulta
        /// </summary>
        public string? Observaciones { get; set; }

        /// <summary>
        /// Diagnóstico asociado
        /// </summary>
        public DiagnosticoDto? Diagnostico { get; set; }
    }

    /// <summary>
    /// DTO para mostrar datos de un diagnóstico
    /// </summary>
    public class DiagnosticoDto
    {
        /// <summary>
        /// ID del diagnóstico
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Descripción del diagnóstico
        /// </summary>
        public string Descripcion { get; set; } = string.Empty;

        /// <summary>
        /// Plan de tratamiento
        /// </summary>
        public string PlanTratamiento { get; set; } = string.Empty;

        /// <summary>
        /// Pronóstico
        /// </summary>
        public string Pronostico { get; set; } = string.Empty;
    }

    /// <summary>
    /// DTO para mostrar datos de una venta
    /// </summary>
    public class VentaDto
    {
        /// <summary>
        /// ID de la venta
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID del paciente
        /// </summary>
        public int PacienteId { get; set; }

        /// <summary>
        /// Nombre del paciente
        /// </summary>
        public string PacienteNombre { get; set; } = string.Empty;

        /// <summary>
        /// ID del producto
        /// </summary>
        public int ProductoId { get; set; }

        /// <summary>
        /// Nombre del producto
        /// </summary>
        public string ProductoNombre { get; set; } = string.Empty;

        /// <summary>
        /// Fecha de la venta
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Cantidad vendida
        /// </summary>
        public int Cantidad { get; set; }

        /// <summary>
        /// Precio unitario
        /// </summary>
        public decimal PrecioUnitario { get; set; }

        /// <summary>
        /// Total de la venta
        /// </summary>
        public decimal Total { get; set; }
    }
} 