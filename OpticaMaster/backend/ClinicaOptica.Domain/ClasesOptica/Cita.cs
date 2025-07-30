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
        /// Fecha y hora de la cita.
        /// </summary>
        [Required]
        public DateTime FechaHora { get; set; }

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

        // Propiedades de navegación
        public virtual Paciente? Paciente { get; set; }
        public virtual Optometrista? Optometrista { get; set; }
    }
}