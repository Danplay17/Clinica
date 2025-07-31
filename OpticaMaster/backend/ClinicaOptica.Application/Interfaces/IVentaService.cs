using ClinicaOptica.Application.DTOs;

namespace ClinicaOptica.Application.Interfaces
{
    /// <summary>
    /// Interfaz para el servicio de gestión de ventas
    /// </summary>
    public interface IVentaService
    {
        /// <summary>
        /// Obtiene todas las ventas
        /// </summary>
        /// <returns>Lista de ventas</returns>
        Task<IEnumerable<VentaDto>> GetAllAsync();

        /// <summary>
        /// Obtiene una venta por ID
        /// </summary>
        /// <param name="id">ID de la venta</param>
        /// <returns>Venta encontrada</returns>
        Task<VentaDto?> GetByIdAsync(int id);

        /// <summary>
        /// Crea una nueva venta
        /// </summary>
        /// <param name="createVentaDto">Datos de la venta a crear</param>
        /// <returns>Venta creada</returns>
        Task<VentaDto> CreateAsync(CreateVentaDto createVentaDto);

        /// <summary>
        /// Actualiza una venta existente
        /// </summary>
        /// <param name="id">ID de la venta</param>
        /// <param name="updateVentaDto">Datos actualizados</param>
        /// <returns>Venta actualizada</returns>
        Task<VentaDto> UpdateAsync(int id, UpdateVentaDto updateVentaDto);

        /// <summary>
        /// Elimina una venta
        /// </summary>
        /// <param name="id">ID de la venta a eliminar</param>
        /// <returns>True si se eliminó correctamente</returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// Obtiene las ventas de un paciente
        /// </summary>
        /// <param name="pacienteId">ID del paciente</param>
        /// <returns>Lista de ventas</returns>
        Task<IEnumerable<VentaDto>> GetByPacienteAsync(int pacienteId);

        /// <summary>
        /// Obtiene las ventas por rango de fechas
        /// </summary>
        /// <param name="fechaDesde">Fecha desde</param>
        /// <param name="fechaHasta">Fecha hasta</param>
        /// <returns>Lista de ventas</returns>
        Task<IEnumerable<VentaDto>> GetByFechaRangeAsync(DateTime fechaDesde, DateTime fechaHasta);

        /// <summary>
        /// Obtiene el total de ventas por período
        /// </summary>
        /// <param name="fechaDesde">Fecha desde</param>
        /// <param name="fechaHasta">Fecha hasta</param>
        /// <returns>Total de ventas</returns>
        Task<decimal> GetTotalVentasAsync(DateTime fechaDesde, DateTime fechaHasta);

        /// <summary>
        /// Obtiene estadísticas de ventas
        /// </summary>
        /// <param name="fechaDesde">Fecha desde</param>
        /// <param name="fechaHasta">Fecha hasta</param>
        /// <returns>Estadísticas de ventas</returns>
        Task<VentasEstadisticasDto> GetEstadisticasAsync(DateTime fechaDesde, DateTime fechaHasta);
    }
} 