using ClinicaOptica.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace ClinicaOptica.Domain.ClasesOptica
{
    /// <summary>
    /// Representa una cita programada.
    /// </summary>
    public class Cita : BaseEntity
    {
        /// <summary>
        /// Identificador del paciente.
        /// </summary>
        [Required]
        public int PacienteId { get; set; }

        /// <summary>
        /// Identificador del optometrista.
        /// </summary>
        [Required]
        public int OptometristaId { get; set; }

        /// <summary>
        /// Fecha de la cita.
        /// </summary>
        [Required]
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Hora de la cita.
        /// </summary>
        [Required]
        public TimeSpan Hora { get; set; }

        /// <summary>
        /// Duración de la cita en minutos.
        /// </summary>
        [Required]
        [Range(15, 180)]
        public int Duracion { get; set; } = 30;

        /// <summary>
        /// Tipo de cita.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Tipo { get; set; } = string.Empty;

        /// <summary>
        /// Estado de la cita.
        /// </summary>
        [Required]
        [StringLength(30)]
        public string Estado { get; set; } = "Programada";

        /// <summary>
        /// Observaciones adicionales de la cita.
        /// </summary>
        [StringLength(500)]
        public string? Observaciones { get; set; }

        // Propiedades de navegación
        public virtual Paciente? Paciente { get; set; }
        public virtual Optometrista? Optometrista { get; set; }
    }
}