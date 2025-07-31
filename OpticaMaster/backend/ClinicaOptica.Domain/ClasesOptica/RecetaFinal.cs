using System.ComponentModel.DataAnnotations;
using ClinicaOptica.Domain.ValueObjects;

namespace ClinicaOptica.Domain.ClasesOptica
{
    /// <summary>
    /// Representa la receta final de la hoja clínica.
    /// Contiene la graduación definitiva para la fabricación de lentes.
    /// </summary>
    public class RecetaFinal : BaseEntity
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
        /// Prismas si se requieren.
        /// </summary>
        [StringLength(100)]
        public string? Prismas { get; set; }

        /// <summary>
        /// Distancia interpupilar (DI).
        /// </summary>
        [StringLength(50)]
        public string? DI { get; set; }

        /// <summary>
        /// Adición para lentes bifocales o progresivos.
        /// </summary>
        [StringLength(50)]
        public string? ADD { get; set; }

        /// <summary>
        /// Material recomendado para los lentes.
        /// </summary>
        [StringLength(100)]
        public string? Material { get; set; }

        /// <summary>
        /// Tratamiento adicional si se requiere.
        /// </summary>
        [StringLength(200)]
        public string? Tratamiento { get; set; }

        /// <summary>
        /// Observaciones finales de la receta.
        /// </summary>
        [StringLength(500)]
        public string? Observaciones { get; set; }

        // Propiedades de navegación

        /// <summary>
        /// Consulta asociada a esta receta final.
        /// </summary>
        public virtual Consulta? Consulta { get; set; }
    }
} 