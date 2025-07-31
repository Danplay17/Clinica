using System.ComponentModel.DataAnnotations;

namespace ClinicaOptica.Application.DTOs
{
    /// <summary>
    /// DTO para crear una nueva consulta
    /// </summary>
    public class CreateConsultaDto
    {
        /// <summary>
        /// ID del paciente
        /// </summary>
        [Required(ErrorMessage = "El paciente es obligatorio")]
        public int PacienteId { get; set; }

        /// <summary>
        /// ID del optometrista
        /// </summary>
        [Required(ErrorMessage = "El optometrista es obligatorio")]
        public int OptometristaId { get; set; }

        /// <summary>
        /// Fecha de la consulta
        /// </summary>
        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Observaciones de la consulta
        /// </summary>
        [StringLength(1000, ErrorMessage = "Las observaciones no pueden exceder 1000 caracteres")]
        public string? Observaciones { get; set; }

        /// <summary>
        /// Diagnóstico asociado
        /// </summary>
        public CreateDiagnosticoDto? Diagnostico { get; set; }
    }

    /// <summary>
    /// DTO para actualizar una consulta
    /// </summary>
    public class UpdateConsultaDto
    {
        /// <summary>
        /// Fecha de la consulta
        /// </summary>
        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Observaciones de la consulta
        /// </summary>
        [StringLength(1000, ErrorMessage = "Las observaciones no pueden exceder 1000 caracteres")]
        public string? Observaciones { get; set; }

        /// <summary>
        /// Diagnóstico asociado
        /// </summary>
        public UpdateDiagnosticoDto? Diagnostico { get; set; }
    }

    /// <summary>
    /// DTO para crear un diagnóstico
    /// </summary>
    public class CreateDiagnosticoDto
    {
        /// <summary>
        /// Descripción del diagnóstico
        /// </summary>
        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres")]
        public string Descripcion { get; set; } = string.Empty;

        /// <summary>
        /// Plan de tratamiento
        /// </summary>
        [StringLength(500, ErrorMessage = "El plan de tratamiento no puede exceder 500 caracteres")]
        public string PlanTratamiento { get; set; } = string.Empty;

        /// <summary>
        /// Pronóstico
        /// </summary>
        [StringLength(500, ErrorMessage = "El pronóstico no puede exceder 500 caracteres")]
        public string Pronostico { get; set; } = string.Empty;
    }

    /// <summary>
    /// DTO para actualizar un diagnóstico
    /// </summary>
    public class UpdateDiagnosticoDto
    {
        /// <summary>
        /// Descripción del diagnóstico
        /// </summary>
        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres")]
        public string Descripcion { get; set; } = string.Empty;

        /// <summary>
        /// Plan de tratamiento
        /// </summary>
        [StringLength(500, ErrorMessage = "El plan de tratamiento no puede exceder 500 caracteres")]
        public string PlanTratamiento { get; set; } = string.Empty;

        /// <summary>
        /// Pronóstico
        /// </summary>
        [StringLength(500, ErrorMessage = "El pronóstico no puede exceder 500 caracteres")]
        public string Pronostico { get; set; } = string.Empty;
    }
} 