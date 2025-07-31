using ClinicaOptica.Domain.ClasesOptica;

namespace ClinicaOptica.Application.Interfaces
{
    /// <summary>
    /// Interfaz para el repositorio de pacientes
    /// </summary>
    public interface IPacienteRepository
    {
        /// <summary>
        /// Obtiene todos los pacientes
        /// </summary>
        /// <returns>Lista de pacientes</returns>
        Task<IEnumerable<Paciente>> GetAllAsync();

        /// <summary>
        /// Obtiene un paciente por ID
        /// </summary>
        /// <param name="id">ID del paciente</param>
        /// <returns>Paciente encontrado o null</returns>
        Task<Paciente?> GetByIdAsync(int id);

        /// <summary>
        /// Busca pacientes por nombre
        /// </summary>
        /// <param name="nombre">Nombre a buscar</param>
        /// <returns>Lista de pacientes que coinciden</returns>
        Task<IEnumerable<Paciente>> SearchByNameAsync(string nombre);

        /// <summary>
        /// Busca pacientes por teléfono
        /// </summary>
        /// <param name="telefono">Teléfono a buscar</param>
        /// <returns>Lista de pacientes que coinciden</returns>
        Task<IEnumerable<Paciente>> SearchByPhoneAsync(string telefono);

        /// <summary>
        /// Crea un nuevo paciente
        /// </summary>
        /// <param name="paciente">Datos del paciente</param>
        /// <returns>Paciente creado</returns>
        Task<Paciente> CreateAsync(Paciente paciente);

        /// <summary>
        /// Actualiza un paciente existente
        /// </summary>
        /// <param name="paciente">Datos actualizados del paciente</param>
        /// <returns>Paciente actualizado</returns>
        Task<Paciente> UpdateAsync(Paciente paciente);

        /// <summary>
        /// Elimina un paciente
        /// </summary>
        /// <param name="id">ID del paciente a eliminar</param>
        /// <returns>True si se eliminó correctamente</returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// Verifica si existe un paciente con el email especificado
        /// </summary>
        /// <param name="email">Email a verificar</param>
        /// <param name="excludeId">ID a excluir de la búsqueda</param>
        /// <returns>True si existe</returns>
        Task<bool> ExistsByEmailAsync(string email, int? excludeId = null);
    }
} 