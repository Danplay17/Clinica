using ClinicaOptica.Domain.ClasesOptica;

namespace ClinicaOptica.Application.Interfaces
{
    /// <summary>
    /// Interfaz para el repositorio de citas
    /// </summary>
    public interface ICitaRepository
    {
        /// <summary>
        /// Obtiene todas las citas
        /// </summary>
        /// <returns>Lista de citas</returns>
        Task<IEnumerable<Cita>> GetAllAsync();

        /// <summary>
        /// Obtiene una cita por ID
        /// </summary>
        /// <param name="id">ID de la cita</param>
        /// <returns>Cita encontrada o null</returns>
        Task<Cita?> GetByIdAsync(int id);

        /// <summary>
        /// Crea una nueva cita
        /// </summary>
        /// <param name="cita">Datos de la cita</param>
        /// <returns>Cita creada</returns>
        Task<Cita> CreateAsync(Cita cita);

        /// <summary>
        /// Actualiza una cita existente
        /// </summary>
        /// <param name="cita">Datos actualizados de la cita</param>
        /// <returns>Cita actualizada</returns>
        Task<Cita> UpdateAsync(Cita cita);

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
        Task<IEnumerable<Cita>> GetByPacienteAsync(int pacienteId);

        /// <summary>
        /// Obtiene las citas de un optometrista
        /// </summary>
        /// <param name="optometristaId">ID del optometrista</param>
        /// <returns>Lista de citas</returns>
        Task<IEnumerable<Cita>> GetByOptometristaAsync(int optometristaId);

        /// <summary>
        /// Obtiene las citas por fecha
        /// </summary>
        /// <param name="fecha">Fecha de las citas</param>
        /// <returns>Lista de citas</returns>
        Task<IEnumerable<Cita>> GetByFechaAsync(DateTime fecha);

        /// <summary>
        /// Obtiene las citas por rango de fechas
        /// </summary>
        /// <param name="fechaDesde">Fecha desde</param>
        /// <param name="fechaHasta">Fecha hasta</param>
        /// <returns>Lista de citas</returns>
        Task<IEnumerable<Cita>> GetByFechaRangeAsync(DateTime fechaDesde, DateTime fechaHasta);

        /// <summary>
        /// Obtiene las citas por estado
        /// </summary>
        /// <param name="estado">Estado de las citas</param>
        /// <returns>Lista de citas</returns>
        Task<IEnumerable<Cita>> GetByEstadoAsync(string estado);

        /// <summary>
        /// Verifica disponibilidad de horario
        /// </summary>
        /// <param name="optometristaId">ID del optometrista</param>
        /// <param name="fecha">Fecha de la cita</param>
        /// <param name="hora">Hora de la cita</param>
        /// <param name="duracion">Duración en minutos</param>
        /// <param name="excludeCitaId">ID de cita a excluir</param>
        /// <returns>True si está disponible</returns>
        Task<bool> VerificarDisponibilidadAsync(int optometristaId, DateTime fecha, TimeSpan hora, int duracion, int? excludeCitaId = null);

        /// <summary>
        /// Obtiene las citas del día para un optometrista
        /// </summary>
        /// <param name="optometristaId">ID del optometrista</param>
        /// <param name="fecha">Fecha del día</param>
        /// <returns>Lista de citas</returns>
        Task<IEnumerable<Cita>> GetCitasDelDiaAsync(int optometristaId, DateTime fecha);
    }
} 