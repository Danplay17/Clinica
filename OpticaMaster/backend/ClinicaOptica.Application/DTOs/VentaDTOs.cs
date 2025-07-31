using System.ComponentModel.DataAnnotations;

namespace ClinicaOptica.Application.DTOs
{
    /// <summary>
    /// DTO para crear una nueva venta
    /// </summary>
    public class CreateVentaDto
    {
        /// <summary>
        /// ID del paciente
        /// </summary>
        [Required(ErrorMessage = "El paciente es obligatorio")]
        public int PacienteId { get; set; }

        /// <summary>
        /// ID del producto
        /// </summary>
        [Required(ErrorMessage = "El producto es obligatorio")]
        public int ProductoId { get; set; }

        /// <summary>
        /// Cantidad vendida
        /// </summary>
        [Required(ErrorMessage = "La cantidad es obligatoria")]
        [Range(1, 100, ErrorMessage = "La cantidad debe estar entre 1 y 100")]
        public int Cantidad { get; set; }

        /// <summary>
        /// Fecha de la venta
        /// </summary>
        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime Fecha { get; set; }
    }

    /// <summary>
    /// DTO para actualizar una venta
    /// </summary>
    public class UpdateVentaDto
    {
        /// <summary>
        /// Cantidad vendida
        /// </summary>
        [Required(ErrorMessage = "La cantidad es obligatoria")]
        [Range(1, 100, ErrorMessage = "La cantidad debe estar entre 1 y 100")]
        public int Cantidad { get; set; }

        /// <summary>
        /// Fecha de la venta
        /// </summary>
        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime Fecha { get; set; }
    }

    /// <summary>
    /// DTO para estadísticas de ventas
    /// </summary>
    public class VentasEstadisticasDto
    {
        /// <summary>
        /// Total de ventas en el período
        /// </summary>
        public decimal TotalVentas { get; set; }

        /// <summary>
        /// Número total de transacciones
        /// </summary>
        public int NumeroTransacciones { get; set; }

        /// <summary>
        /// Promedio por venta
        /// </summary>
        public decimal PromedioPorVenta { get; set; }

        /// <summary>
        /// Producto más vendido
        /// </summary>
        public string ProductoMasVendido { get; set; } = string.Empty;

        /// <summary>
        /// Cantidad del producto más vendido
        /// </summary>
        public int CantidadProductoMasVendido { get; set; }

        /// <summary>
        /// Ventas por día
        /// </summary>
        public List<VentaPorDiaDto> VentasPorDia { get; set; } = new();

        /// <summary>
        /// Ventas por producto
        /// </summary>
        public List<VentaPorProductoDto> VentasPorProducto { get; set; } = new();
    }

    /// <summary>
    /// DTO para ventas por día
    /// </summary>
    public class VentaPorDiaDto
    {
        /// <summary>
        /// Fecha
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Total de ventas del día
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Número de transacciones del día
        /// </summary>
        public int NumeroTransacciones { get; set; }
    }

    /// <summary>
    /// DTO para ventas por producto
    /// </summary>
    public class VentaPorProductoDto
    {
        /// <summary>
        /// ID del producto
        /// </summary>
        public int ProductoId { get; set; }

        /// <summary>
        /// Nombre del producto
        /// </summary>
        public string ProductoNombre { get; set; } = string.Empty;

        /// <summary>
        /// Cantidad vendida
        /// </summary>
        public int Cantidad { get; set; }

        /// <summary>
        /// Total vendido
        /// </summary>
        public decimal Total { get; set; }
    }
} 