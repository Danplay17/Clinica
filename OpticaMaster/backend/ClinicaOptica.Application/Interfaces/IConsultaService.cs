using ClinicaOptica.Application.DTOs;

namespace ClinicaOptica.Application.Interfaces
{
    /// <summary>
    /// Interfaz para el servicio de gestión de consultas
    /// </summary>
    public interface IConsultaService
    {
        /// <summary>
        /// Obtiene todas las consultas
        /// </summary>
        /// <returns>Lista de consultas</returns>
        Task<IEnumerable<ConsultaDto>> GetAllAsync();

        /// <summary>
        /// Obtiene una consulta por ID
        /// </summary>
        /// <param name="id">ID de la consulta</param>
        /// <returns>Consulta encontrada</returns>
        Task<ConsultaDto?> GetByIdAsync(int id);

        /// <summary>
        /// Crea una nueva consulta
        /// </summary>
        /// <param name="createConsultaDto">Datos de la consulta a crear</param>
        /// <returns>Consulta creada</returns>
        Task<ConsultaDto> CreateAsync(CreateConsultaDto createConsultaDto);

        /// <summary>
        /// Actualiza una consulta existente
        /// </summary>
        /// <param name="id">ID de la consulta</param>
        /// <param name="updateConsultaDto">Datos actualizados</param>
        /// <returns>Consulta actualizada</returns>
        Task<ConsultaDto> UpdateAsync(int id, UpdateConsultaDto updateConsultaDto);

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
        Task<IEnumerable<ConsultaDto>> GetByPacienteAsync(int pacienteId);

        /// <summary>
        /// Obtiene las consultas de un optometrista
        /// </summary>
        /// <param name="optometristaId">ID del optometrista</param>
        /// <returns>Lista de consultas</returns>
        Task<IEnumerable<ConsultaDto>> GetByOptometristaAsync(int optometristaId);

        /// <summary>
        /// Obtiene las consultas por rango de fechas
        /// </summary>
        /// <param name="fechaDesde">Fecha desde</param>
        /// <param name="fechaHasta">Fecha hasta</param>
        /// <returns>Lista de consultas</returns>
        Task<IEnumerable<ConsultaDto>> GetByFechaRangeAsync(DateTime fechaDesde, DateTime fechaHasta);
    }
} 