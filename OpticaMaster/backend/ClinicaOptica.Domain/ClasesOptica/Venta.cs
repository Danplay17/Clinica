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
        /// Identificador del producto vendido.
        /// </summary>
        [Required]
        public int ProductoId { get; set; }

        /// <summary>
        /// Cantidad vendida.
        /// </summary>
        [Required]
        [Range(1, int.MaxValue)]
        public int Cantidad { get; set; }

        /// <summary>
        /// Precio unitario al momento de la venta.
        /// </summary>
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal PrecioUnitario { get; set; }

        /// <summary>
        /// Total de la venta.
        /// </summary>
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Total { get; set; }

        // Propiedades de navegación
        public virtual Paciente? Paciente { get; set; }
        public virtual Producto? Producto { get; set; }
    }
}