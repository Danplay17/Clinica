using ClinicaOptica.Application.DTOs;

namespace ClinicaOptica.Application.Interfaces
{
    /// <summary>
    /// Interfaz para el servicio de gestión de citas
    /// </summary>
    public interface ICitaService
    {
        /// <summary>
        /// Obtiene todas las citas
        /// </summary>
        /// <returns>Lista de citas</returns>
        Task<IEnumerable<CitaDto>> GetAllAsync();

        /// <summary>
        /// Obtiene una cita por ID
        /// </summary>
        /// <param name="id">ID de la cita</param>
        /// <returns>Cita encontrada</returns>
        Task<CitaDto?> GetByIdAsync(int id);

        /// <summary>
        /// Crea una nueva cita
        /// </summary>
        /// <param name="createCitaDto">Datos de la cita a crear</param>
        /// <returns>Cita creada</returns>
        Task<CitaDto> CreateAsync(CreateCitaDto createCitaDto);

        /// <summary>
        /// Actualiza una cita existente
        /// </summary>
        /// <param name="id">ID de la cita</param>
        /// <param name="updateCitaDto">Datos actualizados</param>
        /// <returns>Cita actualizada</returns>
        Task<CitaDto> UpdateAsync(int id, UpdateCitaDto updateCitaDto);

        /// <summary>
        /// Elimina una cita
        /// </summary>
        /// <param name="id">ID de la cita a eliminar</param>
        /// <returns>True si se eliminó correctamente</returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// Obtiene las citas de un paciente
        /// </summary>
        /// <param name="pacienteId">ID del paciente</param>
        /// <returns>Lista de citas</returns>
        Task<IEnumerable<CitaDto>> GetByPacienteAsync(int pacienteId);

        /// <summary>
        /// Obtiene las citas de un optometrista
        /// </summary>
        /// <param name="optometristaId">ID del optometrista</param>
        /// <returns>Lista de citas</returns>
        Task<IEnumerable<CitaDto>> GetByOptometristaAsync(int optometristaId);

        /// <summary>
        /// Obtiene las citas por fecha
        /// </summary>
        /// <param name="fecha">Fecha de las citas</param>
        /// <returns>Lista de citas</returns>
        Task<IEnumerable<CitaDto>> GetByFechaAsync(DateTime fecha);

        /// <summary>
        /// Obtiene las citas por rango de fechas
        /// </summary>
        /// <param name="fechaDesde">Fecha desde</param>
        /// <param name="fechaHasta">Fecha hasta</param>
        /// <returns>Lista de citas</returns>
        Task<IEnumerable<CitaDto>> GetByFechaRangeAsync(DateTime fechaDesde, DateTime fechaHasta);

        /// <summary>
        /// Obtiene las citas por estado
        /// </summary>
        /// <param name="estado">Estado de las citas</param>
        /// <returns>Lista de citas</returns>
        Task<IEnumerable<CitaDto>> GetByEstadoAsync(string estado);

        /// <summary>
        /// Verifica disponibilidad de horario
        /// </summary>
        /// <param name="optometristaId">ID del optometrista</param>
        /// <param name="fecha">Fecha de la cita</param>
        /// <param name="hora">Hora de la cita</param>
        /// <param name="duracion">Duración en minutos</param>
        /// <param name="excludeCitaId">ID de cita a excluir (para actualizaciones)</param>
        /// <returns>True si está disponible</returns>
        Task<bool> VerificarDisponibilidadAsync(int optometristaId, DateTime fecha, TimeSpan hora, int duracion, int? excludeCitaId = null);

        /// <summary>
        /// Cancela una cita
        /// </summary>
        /// <param name="id">ID de la cita</param>
        /// <returns>Cita cancelada</returns>
        Task<CitaDto> CancelarAsync(int id);

        /// <summary>
        /// Confirma una cita
        /// </summary>
        /// <param name="id">ID de la cita</param>
        /// <returns>Cita confirmada</returns>
        Task<CitaDto> ConfirmarAsync(int id);
    }
} 