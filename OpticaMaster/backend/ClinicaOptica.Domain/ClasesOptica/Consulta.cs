using System.ComponentModel.DataAnnotations;
using ClinicaOptica.Domain.ValueObjects;

namespace ClinicaOptica.Domain.ClasesOptica
{
    /// <summary>
    /// Representa una consulta realizada a un paciente.
    /// Contiene toda la información de la hoja clínica digitalizada.
    /// </summary>
    public class Consulta : BaseEntity
    {
        /// <summary>
        /// Identificador del paciente.
        /// </summary>
        [Required]
        public int PacienteId { get; set; }

        /// <summary>
        /// Identificador del optometrista que realiza la consulta.
        /// </summary>
        [Required]
        public int OptometristaId { get; set; }

        /// <summary>
        /// Fecha y hora de la consulta.
        /// </summary>
        [Required]
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Observaciones generales de la consulta.
        /// </summary>
        [StringLength(500)]
        public string? Observaciones { get; set; }

        // Propiedades de navegación básicas
        public virtual Paciente? Paciente { get; set; }
        public virtual Optometrista? Optometrista { get; set; }
        public virtual Diagnostico? Diagnostico { get; set; }

        // Propiedades de navegación para secciones clínicas
        public virtual Antecedentes? Antecedentes { get; set; }
        public virtual AgudezaVisual? AgudezaVisual { get; set; }
        public virtual Lensometria? Lensometria { get; set; }
        public virtual Refraccion? Refraccion { get; set; }
        public virtual RecetaFinal? RecetaFinal { get; set; }
    }
}