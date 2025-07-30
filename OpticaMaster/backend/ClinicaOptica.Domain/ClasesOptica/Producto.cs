using ClinicaOptica.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace ClinicaOptica.Domain.ClasesOptica
{
    /// <summary>
    /// Representa un producto óptico.
    /// </summary>
    public class Producto : BaseEntity
    {
        /// <summary>
        /// Nombre del producto.
        /// </summary>
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Tipo de producto.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Tipo { get; set; } = string.Empty;

        /// <summary>
        /// Descripción del producto.
        /// </summary>
        [StringLength(500)]
        public string? Descripcion { get; set; }

        /// <summary>
        /// Precio del producto.
        /// </summary>
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Precio { get; set; }

        /// <summary>
        /// Stock disponible.
        /// </summary>
        [Required]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        /// <summary>
        /// Indica si el producto está activo.
        /// </summary>
        public bool Activo { get; set; } = true;
    }
}