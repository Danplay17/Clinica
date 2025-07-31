using ClinicaOptica.Application.DTOs;

namespace ClinicaOptica.Application.Interfaces
{
    /// <summary>
    /// Interfaz para el servicio de gestión de optometristas
    /// </summary>
    public interface IOptometristaService
    {
        /// <summary>
        /// Obtiene todos los optometristas
        /// </summary>
        /// <returns>Lista de optometristas</returns>
        Task<IEnumerable<OptometristaDto>> GetAllAsync();

        /// <summary>
        /// Obtiene un optometrista por ID
        /// </summary>
        /// <param name="id">ID del optometrista</param>
        /// <returns>Optometrista encontrado</returns>
        Task<OptometristaDto?> GetByIdAsync(int id);

        /// <summary>
        /// Crea un nuevo optometrista
        /// </summary>
        /// <param name="createOptometristaDto">Datos del optometrista a crear</param>
        /// <returns>Optometrista creado</returns>
        Task<OptometristaDto> CreateAsync(CreateOptometristaDto createOptometristaDto);

        /// <summary>
        /// Actualiza un optometrista existente
        /// </summary>
        /// <param name="id">ID del optometrista</param>
        /// <param name="updateOptometristaDto">Datos actualizados</param>
        /// <returns>Optometrista actualizado</returns>
        Task<OptometristaDto> UpdateAsync(int id, UpdateOptometristaDto updateOptometristaDto);

        /// <summary>
        /// Elimina un optometrista
        /// </summary>
        /// <param name="id">ID del optometrista a eliminar</param>
        /// <returns>True si se eliminó correctamente</returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// Obtiene las consultas de un optometrista
        /// </summary>
        /// <param name="optometristaId">ID del optometrista</param>
        /// <returns>Lista de consultas</returns>
        Task<IEnumerable<ConsultaDto>> GetConsultasAsync(int optometristaId);

        /// <summary>
        /// Obtiene las citas de un optometrista
        /// </summary>
        /// <param name="optometristaId">ID del optometrista</param>
        /// <returns>Lista de citas</returns>
        Task<IEnumerable<CitaDto>> GetCitasAsync(int optometristaId);
    }
} 