using ClinicaOptica.Domain.ClasesOptica;

namespace ClinicaOptica.Application.Interfaces
{
    /// <summary>
    /// Interfaz para el repositorio de ventas
    /// </summary>
    public interface IVentaRepository
    {
        /// <summary>
        /// Obtiene todas las ventas
        /// </summary>
        /// <returns>Lista de ventas</returns>
        Task<IEnumerable<Venta>> GetAllAsync();

        /// <summary>
        /// Obtiene una venta por ID
        /// </summary>
        /// <param name="id">ID de la venta</param>
        /// <returns>Venta encontrada o null</returns>
        Task<Venta?> GetByIdAsync(int id);

        /// <summary>
        /// Crea una nueva venta
        /// </summary>
        /// <param name="venta">Datos de la venta</param>
        /// <returns>Venta creada</returns>
        Task<Venta> CreateAsync(Venta venta);

        /// <summary>
        /// Actualiza una venta existente
        /// </summary>
        /// <param name="venta">Datos actualizados de la venta</param>
        /// <returns>Venta actualizada</returns>
        Task<Venta> UpdateAsync(Venta venta);

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
        Task<IEnumerable<Venta>> GetByPacienteAsync(int pacienteId);

        /// <summary>
        /// Obtiene las ventas por rango de fechas
        /// </summary>
        /// <param name="fechaDesde">Fecha desde</param>
        /// <param name="fechaHasta">Fecha hasta</param>
        /// <returns>Lista de ventas</returns>
        Task<IEnumerable<Venta>> GetByFechaRangeAsync(DateTime fechaDesde, DateTime fechaHasta);

        /// <summary>
        /// Obtiene el total de ventas por período
        /// </summary>
        /// <param name="fechaDesde">Fecha desde</param>
        /// <param name="fechaHasta">Fecha hasta</param>
        /// <returns>Total de ventas</returns>
        Task<decimal> GetTotalVentasAsync(DateTime fechaDesde, DateTime fechaHasta);

        /// <summary>
        /// Obtiene estadísticas de ventas por día
        /// </summary>
        /// <param name="fechaDesde">Fecha desde</param>
        /// <param name="fechaHasta">Fecha hasta</param>
        /// <returns>Estadísticas de ventas por día</returns>
        Task<IEnumerable<object>> GetEstadisticasPorDiaAsync(DateTime fechaDesde, DateTime fechaHasta);

        /// <summary>
        /// Obtiene estadísticas de ventas por producto
        /// </summary>
        /// <param name="fechaDesde">Fecha desde</param>
        /// <param name="fechaHasta">Fecha hasta</param>
        /// <returns>Estadísticas de ventas por producto</returns>
        Task<IEnumerable<object>> GetEstadisticasPorProductoAsync(DateTime fechaDesde, DateTime fechaHasta);
    }
} 