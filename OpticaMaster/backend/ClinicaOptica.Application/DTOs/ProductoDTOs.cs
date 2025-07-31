using System.ComponentModel.DataAnnotations;

namespace ClinicaOptica.Application.DTOs
{
    /// <summary>
    /// DTO para mostrar datos de un producto
    /// </summary>
    public class ProductoDto
    {
        /// <summary>
        /// ID del producto
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del producto
        /// </summary>
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Tipo de producto
        /// </summary>
        public string Tipo { get; set; } = string.Empty;

        /// <summary>
        /// Descripción del producto
        /// </summary>
        public string? Descripcion { get; set; }

        /// <summary>
        /// Precio del producto
        /// </summary>
        public decimal Precio { get; set; }

        /// <summary>
        /// Stock disponible
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Indica si el producto está activo
        /// </summary>
        public bool Activo { get; set; }
    }

    /// <summary>
    /// DTO para crear un nuevo producto
    /// </summary>
    public class CreateProductoDto
    {
        /// <summary>
        /// Nombre del producto
        /// </summary>
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Tipo de producto
        /// </summary>
        [Required(ErrorMessage = "El tipo es obligatorio")]
        public string Tipo { get; set; } = string.Empty;

        /// <summary>
        /// Descripción del producto
        /// </summary>
        [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres")]
        public string? Descripcion { get; set; }

        /// <summary>
        /// Precio del producto
        /// </summary>
        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0, 999999.99, ErrorMessage = "El precio debe estar entre 0 y 999,999.99")]
        public decimal Precio { get; set; }

        /// <summary>
        /// Stock inicial
        /// </summary>
        [Required(ErrorMessage = "El stock es obligatorio")]
        [Range(0, 9999, ErrorMessage = "El stock debe estar entre 0 y 9999")]
        public int Stock { get; set; }
    }

    /// <summary>
    /// DTO para actualizar un producto
    /// </summary>
    public class UpdateProductoDto
    {
        /// <summary>
        /// Nombre del producto
        /// </summary>
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Tipo de producto
        /// </summary>
        [Required(ErrorMessage = "El tipo es obligatorio")]
        public string Tipo { get; set; } = string.Empty;

        /// <summary>
        /// Descripción del producto
        /// </summary>
        [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres")]
        public string? Descripcion { get; set; }

        /// <summary>
        /// Precio del producto
        /// </summary>
        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0, 999999.99, ErrorMessage = "El precio debe estar entre 0 y 999,999.99")]
        public decimal Precio { get; set; }

        /// <summary>
        /// Stock disponible
        /// </summary>
        [Required(ErrorMessage = "El stock es obligatorio")]
        [Range(0, 9999, ErrorMessage = "El stock debe estar entre 0 y 9999")]
        public int Stock { get; set; }

        /// <summary>
        /// Indica si el producto está activo
        /// </summary>
        public bool Activo { get; set; }
    }
} 