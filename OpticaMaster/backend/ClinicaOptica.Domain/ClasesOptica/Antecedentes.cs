using System.ComponentModel.DataAnnotations;
using ClinicaOptica.Domain.ValueObjects;

namespace ClinicaOptica.Domain.ClasesOptica
{
    /// <summary>
    /// Representa la sección de antecedentes de la hoja clínica.
    /// Contiene información médica y familiar del paciente.
    /// </summary>
    public class Antecedentes : BaseEntity
    {
        /// <summary>
        /// Identificador de la consulta asociada.
        /// Clave foránea hacia Consulta.
        /// </summary>
        [Required]
        public int ConsultaId { get; set; }

        /// <summary>
        /// Antecedentes hereditarios y familiares.
        /// Información sobre condiciones oculares en la familia.
        /// </summary>
        [StringLength(500)]
        public string? HeredoFamiliares { get; set; }

        /// <summary>
        /// Antecedentes no patológicos.
        /// Hábitos, estilo de vida, etc.
        /// </summary>
        [StringLength(500)]
        public string? NoPatologicos { get; set; }

        /// <summary>
        /// Antecedentes patológicos.
        /// Enfermedades previas, cirugías, etc.
        /// </summary>
        [StringLength(500)]
        public string? Patologicos { get; set; }

        /// <summary>
        /// Padecimiento actual del paciente.
        /// Síntomas y motivo de consulta.
        /// </summary>
        [StringLength(500)]
        public string? PadecimientoActual { get; set; }

        /// <summary>
        /// Prediagnóstico inicial.
        /// Evaluación preliminar del optometrista.
        /// </summary>
        [StringLength(500)]
        public string? Prediagnostico { get; set; }

        // Propiedades de navegación

        /// <summary>
        /// Consulta asociada a estos antecedentes.
        /// </summary>
        public virtual Consulta? Consulta { get; set; }
    }
} 