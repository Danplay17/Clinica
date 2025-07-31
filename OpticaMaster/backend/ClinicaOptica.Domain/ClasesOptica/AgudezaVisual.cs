using System.ComponentModel.DataAnnotations;
using ClinicaOptica.Domain.ValueObjects;

namespace ClinicaOptica.Domain.ClasesOptica
{
    /// <summary>
    /// Representa la sección de agudeza visual de la hoja clínica.
    /// Mide la capacidad visual del paciente con y sin corrección.
    /// </summary>
    public class AgudezaVisual : BaseEntity
    {
        /// <summary>
        /// Identificador de la consulta asociada.
        /// </summary>
        [Required]
        public int ConsultaId { get; set; }

        // Agudeza visual sin corrección - Ojo Derecho
        [StringLength(10)]
        public string? SinRxLejosOD { get; set; }

        [StringLength(10)]
        public string? SinRxCercaOD { get; set; }

        // Agudeza visual sin corrección - Ojo Izquierdo
        [StringLength(10)]
        public string? SinRxLejosOI { get; set; }

        [StringLength(10)]
        public string? SinRxCercaOI { get; set; }

        // Agudeza visual con corrección - Ojo Derecho
        [StringLength(10)]
        public string? ConRxLejosOD { get; set; }

        [StringLength(10)]
        public string? ConRxCercaOD { get; set; }

        // Agudeza visual con corrección - Ojo Izquierdo
        [StringLength(10)]
        public string? ConRxLejosOI { get; set; }

        [StringLength(10)]
        public string? ConRxCercaOI { get; set; }

        /// <summary>
        /// Observaciones adicionales sobre la agudeza visual.
        /// </summary>
        [StringLength(200)]
        public string? Observaciones { get; set; }

        // Propiedades de navegación

        /// <summary>
        /// Consulta asociada a esta medición de agudeza visual.
        /// </summary>
        public virtual Consulta? Consulta { get; set; }
    }
} 