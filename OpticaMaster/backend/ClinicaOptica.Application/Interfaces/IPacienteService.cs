using ClinicaOptica.Application.DTOs;

namespace ClinicaOptica.Application.Interfaces
{
    /// <summary>
    /// Interfaz para el servicio de gestión de pacientes
    /// </summary>
    public interface IPacienteService
    {
        /// <summary>
        /// Obtiene todos los pacientes
        /// </summary>
        /// <returns>Lista de pacientes</returns>
        Task<IEnumerable<PacienteDto>> GetAllAsync();

        /// <summary>
        /// Obtiene un paciente por ID
        /// </summary>
        /// <param name="id">ID del paciente</param>
        /// <returns>Paciente encontrado</returns>
        Task<PacienteDto?> GetByIdAsync(int id);

        /// <summary>
        /// Busca pacientes por nombre
        /// </summary>
        /// <param name="nombre">Nombre a buscar</param>
        /// <returns>Lista de pacientes que coinciden</returns>
        Task<IEnumerable<PacienteDto>> SearchByNameAsync(string nombre);

        /// <summary>
        /// Busca pacientes por teléfono
        /// </summary>
        /// <param name="telefono">Teléfono a buscar</param>
        /// <returns>Lista de pacientes que coinciden</returns>
        Task<IEnumerable<PacienteDto>> SearchByPhoneAsync(string telefono);

        /// <summary>
        /// Crea un nuevo paciente
        /// </summary>
        /// <param name="createPacienteDto">Datos del paciente a crear</param>
        /// <returns>Paciente creado</returns>
        Task<PacienteDto> CreateAsync(CreatePacienteDto createPacienteDto);

        /// <summary>
        /// Actualiza un paciente existente
        /// </summary>
        /// <param name="id">ID del paciente</param>
        /// <param name="updatePacienteDto">Datos actualizados</param>
        /// <returns>Paciente actualizado</returns>
        Task<PacienteDto> UpdateAsync(int id, UpdatePacienteDto updatePacienteDto);

        /// <summary>
        /// Elimina un paciente
        /// </summary>
        /// <param name="id">ID del paciente a eliminar</param>
        /// <returns>True si se eliminó correctamente</returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// Obtiene el historial de consultas de un paciente
        /// </summary>
        /// <param name="pacienteId">ID del paciente</param>
        /// <returns>Lista de consultas</returns>
        Task<IEnumerable<ConsultaDto>> GetConsultasAsync(int pacienteId);

        /// <summary>
        /// Obtiene el historial de ventas de un paciente
        /// </summary>
        /// <param name="pacienteId">ID del paciente</param>
        /// <returns>Lista de ventas</returns>
        Task<IEnumerable<VentaDto>> GetVentasAsync(int pacienteId);
    }
} 