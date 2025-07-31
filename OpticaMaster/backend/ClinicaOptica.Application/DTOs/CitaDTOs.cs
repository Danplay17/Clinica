using System.ComponentModel.DataAnnotations;

namespace ClinicaOptica.Application.DTOs
{
    /// <summary>
    /// DTO para mostrar datos de una cita
    /// </summary>
    public class CitaDto
    {
        /// <summary>
        /// ID de la cita
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
        /// Fecha de la cita
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Hora de la cita
        /// </summary>
        public TimeSpan Hora { get; set; }

        /// <summary>
        /// Tipo de cita
        /// </summary>
        public string Tipo { get; set; } = string.Empty;

        /// <summary>
        /// Estado de la cita
        /// </summary>
        public string Estado { get; set; } = string.Empty;

        /// <summary>
        /// Duración de la cita en minutos
        /// </summary>
        public int Duracion { get; set; }

        /// <summary>
        /// Observaciones de la cita
        /// </summary>
        public string? Observaciones { get; set; }
    }

    /// <summary>
    /// DTO para crear una nueva cita
    /// </summary>
    public class CreateCitaDto
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
        /// Fecha de la cita
        /// </summary>
        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Hora de la cita
        /// </summary>
        [Required(ErrorMessage = "La hora es obligatoria")]
        public TimeSpan Hora { get; set; }

        /// <summary>
        /// Tipo de cita
        /// </summary>
        [Required(ErrorMessage = "El tipo de cita es obligatorio")]
        public string Tipo { get; set; } = string.Empty;

        /// <summary>
        /// Duración de la cita en minutos
        /// </summary>
        [Required(ErrorMessage = "La duración es obligatoria")]
        [Range(15, 120, ErrorMessage = "La duración debe estar entre 15 y 120 minutos")]
        public int Duracion { get; set; }

        /// <summary>
        /// Observaciones de la cita
        /// </summary>
        [StringLength(500, ErrorMessage = "Las observaciones no pueden exceder 500 caracteres")]
        public string? Observaciones { get; set; }
    }

    /// <summary>
    /// DTO para actualizar una cita
    /// </summary>
    public class UpdateCitaDto
    {
        /// <summary>
        /// Fecha de la cita
        /// </summary>
        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Hora de la cita
        /// </summary>
        [Required(ErrorMessage = "La hora es obligatoria")]
        public TimeSpan Hora { get; set; }

        /// <summary>
        /// Tipo de cita
        /// </summary>
        [Required(ErrorMessage = "El tipo de cita es obligatorio")]
        public string Tipo { get; set; } = string.Empty;

        /// <summary>
        /// Estado de la cita
        /// </summary>
        [Required(ErrorMessage = "El estado es obligatorio")]
        public string Estado { get; set; } = string.Empty;

        /// <summary>
        /// Duración de la cita en minutos
        /// </summary>
        [Required(ErrorMessage = "La duración es obligatoria")]
        [Range(15, 120, ErrorMessage = "La duración debe estar entre 15 y 120 minutos")]
        public int Duracion { get; set; }

        /// <summary>
        /// Observaciones de la cita
        /// </summary>
        [StringLength(500, ErrorMessage = "Las observaciones no pueden exceder 500 caracteres")]
        public string? Observaciones { get; set; }
    }

    /// <summary>
    /// DTO para buscar citas por criterios
    /// </summary>
    public class BuscarCitasDto
    {
        /// <summary>
        /// ID del paciente (opcional)
        /// </summary>
        public int? PacienteId { get; set; }

        /// <summary>
        /// ID del optometrista (opcional)
        /// </summary>
        public int? OptometristaId { get; set; }

        /// <summary>
        /// Fecha desde (opcional)
        /// </summary>
        public DateTime? FechaDesde { get; set; }

        /// <summary>
        /// Fecha hasta (opcional)
        /// </summary>
        public DateTime? FechaHasta { get; set; }

        /// <summary>
        /// Estado de la cita (opcional)
        /// </summary>
        public string? Estado { get; set; }

        /// <summary>
        /// Tipo de cita (opcional)
        /// </summary>
        public string? Tipo { get; set; }
    }
} 