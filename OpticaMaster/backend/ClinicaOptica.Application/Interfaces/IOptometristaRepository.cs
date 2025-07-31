using ClinicaOptica.Domain.ClasesOptica;

namespace ClinicaOptica.Application.Interfaces
{
    /// <summary>
    /// Interfaz para el repositorio de optometristas
    /// </summary>
    public interface IOptometristaRepository
    {
        /// <summary>
        /// Obtiene todos los optometristas
        /// </summary>
        /// <returns>Lista de optometristas</returns>
        Task<IEnumerable<Optometrista>> GetAllAsync();

        /// <summary>
        /// Obtiene un optometrista por ID
        /// </summary>
        /// <param name="id">ID del optometrista</param>
        /// <returns>Optometrista encontrado o null</returns>
        Task<Optometrista?> GetByIdAsync(int id);

        /// <summary>
        /// Busca optometristas por nombre
        /// </summary>
        /// <param name="nombre">Nombre a buscar</param>
        /// <returns>Lista de optometristas que coinciden</returns>
        Task<IEnumerable<Optometrista>> SearchByNameAsync(string nombre);

        /// <summary>
        /// Busca optometristas por cédula profesional
        /// </summary>
        /// <param name="cedula">Cédula a buscar</param>
        /// <returns>Optometrista encontrado o null</returns>
        Task<Optometrista?> GetByCedulaAsync(string cedula);

        /// <summary>
        /// Crea un nuevo optometrista
        /// </summary>
        /// <param name="optometrista">Datos del optometrista</param>
        /// <returns>Optometrista creado</returns>
        Task<Optometrista> CreateAsync(Optometrista optometrista);

        /// <summary>
        /// Actualiza un optometrista existente
        /// </summary>
        /// <param name="optometrista">Datos actualizados del optometrista</param>
        /// <returns>Optometrista actualizado</returns>
        Task<Optometrista> UpdateAsync(Optometrista optometrista);

        /// <summary>
        /// Elimina un optometrista
        /// </summary>
        /// <param name="id">ID del optometrista a eliminar</param>
        /// <returns>True si se eliminó correctamente</returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// Verifica si existe un optometrista con la cédula especificada
        /// </summary>
        /// <param name="cedula">Cédula a verificar</param>
        /// <param name="excludeId">ID a excluir de la búsqueda</param>
        /// <returns>True si existe</returns>
        Task<bool> ExistsByCedulaAsync(string cedula, int? excludeId = null);

        /// <summary>
        /// Verifica si existe un optometrista con el correo especificado
        /// </summary>
        /// <param name="correo">Correo a verificar</param>
        /// <param name="excludeId">ID a excluir de la búsqueda</param>
        /// <returns>True si existe</returns>
        Task<bool> ExistsByCorreoAsync(string correo, int? excludeId = null);
    }
} 