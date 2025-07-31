using System.ComponentModel.DataAnnotations;
using ClinicaOptica.Domain.ValueObjects;

namespace ClinicaOptica.Domain.ClasesOptica
{
    /// <summary>
    /// Representa la sección de lensometría de la hoja clínica.
    /// Mide la graduación actual de los lentes del paciente.
    /// </summary>
    public class Lensometria : BaseEntity
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
        /// Tipo de lente bifocal si aplica.
        /// </summary>
        [StringLength(50)]
        public string? TipoBifocal { get; set; }

        /// <summary>
        /// Material de los lentes actuales.
        /// </summary>
        [StringLength(50)]
        public string? Material { get; set; }

        /// <summary>
        /// Observaciones sobre la lensometría.
        /// </summary>
        [StringLength(200)]
        public string? Observaciones { get; set; }

        // Propiedades de navegación

        /// <summary>
        /// Consulta asociada a esta lensometría.
        /// </summary>
        public virtual Consulta? Consulta { get; set; }
    }
} 