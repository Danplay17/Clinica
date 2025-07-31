using ClinicaOptica.Domain.ClasesOptica;

namespace ClinicaOptica.Application.Interfaces
{
    /// <summary>
    /// Interfaz para el repositorio de consultas
    /// </summary>
    public interface IConsultaRepository
    {
        /// <summary>
        /// Obtiene todas las consultas
        /// </summary>
        /// <returns>Lista de consultas</returns>
        Task<IEnumerable<Consulta>> GetAllAsync();

        /// <summary>
        /// Obtiene una consulta por ID
        /// </summary>
        /// <param name="id">ID de la consulta</param>
        /// <returns>Consulta encontrada o null</returns>
        Task<Consulta?> GetByIdAsync(int id);

        /// <summary>
        /// Crea una nueva consulta
        /// </summary>
        /// <param name="consulta">Datos de la consulta</param>
        /// <returns>Consulta creada</returns>
        Task<Consulta> CreateAsync(Consulta consulta);

        /// <summary>
        /// Actualiza una consulta existente
        /// </summary>
        /// <param name="consulta">Datos actualizados de la consulta</param>
        /// <returns>Consulta actualizada</returns>
        Task<Consulta> UpdateAsync(Consulta consulta);

        /// <summary>
        /// Elimina una consulta
        /// </summary>
        /// <param name="id">ID de la consulta a eliminar</param>
        /// <returns>True si se eliminó correctamente</returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// Obtiene las consultas de un paciente
        /// </summary>
        /// <param name="pacienteId">ID del paciente</param>
        /// <returns>Lista de consultas</returns>
        Task<IEnumerable<Consulta>> GetByPacienteAsync(int pacienteId);

        /// <summary>
        /// Obtiene las consultas de un optometrista
        /// </summary>
        /// <param name="optometristaId">ID del optometrista</param>
        /// <returns>Lista de consultas</returns>
        Task<IEnumerable<Consulta>> GetByOptometristaAsync(int optometristaId);

        /// <summary>
        /// Obtiene las consultas por rango de fechas
        /// </summary>
        /// <param name="fechaDesde">Fecha desde</param>
        /// <param name="fechaHasta">Fecha hasta</param>
        /// <returns>Lista de consultas</returns>
        Task<IEnumerable<Consulta>> GetByFechaRangeAsync(DateTime fechaDesde, DateTime fechaHasta);
    }
} 