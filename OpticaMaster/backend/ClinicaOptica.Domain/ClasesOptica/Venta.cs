using ClinicaOptica.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace ClinicaOptica.Domain.ClasesOptica
{
    /// <summary>
    /// Representa una venta de productos.
    /// </summary>
    public class Venta : BaseEntity
    {
        /// <summary>
        /// Identificador del paciente.
        /// </summary>
        [Required]
        public int PacienteId { get; set; }

        /// <summary>
        /// Fecha de la venta.
        /// </summary>
        [Required]
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Total de la venta.
        /// </summary>
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Total { get; set; }

        // Propiedades de navegación
        public virtual Paciente? Paciente { get; set; }
    }
}