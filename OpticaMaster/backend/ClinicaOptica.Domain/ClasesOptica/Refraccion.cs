using System.ComponentModel.DataAnnotations;
using ClinicaOptica.Domain.ValueObjects;

namespace ClinicaOptica.Domain.ClasesOptica
{
    /// <summary>
    /// Representa la sección de refracción de la hoja clínica.
    /// Contiene la graduación determinada por el optometrista.
    /// </summary>
    public class Refraccion : BaseEntity
    {
        /// <summary>
        /// Identificador de la consulta asociada.
        /// </summary>
        [Required]
        public int ConsultaId { get; set; }

        // Ojo Derecho (OD)
        [Range(-20.0, 20.0)]
        public decimal? EsferaOD { get; set; }

        [Range(-6.0, 6.0)]
        public decimal? CilindroOD { get; set; }

        [Range(1, 180)]
        public int? EjeOD { get; set; }

        // Ojo Izquierdo (OI)
        [Range(-20.0, 20.0)]
        public decimal? EsferaOI { get; set; }

        [Range(-6.0, 6.0)]
        public decimal? CilindroOI { get; set; }

        [Range(1, 180)]
        public int? EjeOI { get; set; }

        /// <summary>
        /// Queratometría si se realizó.
        /// </summary>
        [StringLength(200)]
        public string? Queratometria { get; set; }

        /// <summary>
        /// Estado refractivo del paciente.
        /// </summary>
        [StringLength(100)]
        public string? EstadoRefractivo { get; set; }

        /// <summary>
        /// Observaciones sobre la refracción.
        /// </summary>
        [StringLength(200)]
        public string? Observaciones { get; set; }

        // Propiedades de navegación

        /// <summary>
        /// Consulta asociada a esta refracción.
        /// </summary>
        public virtual Consulta? Consulta { get; set; }
    }
} 