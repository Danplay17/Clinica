using ClinicaOptica.Domain.ClasesOptica;

namespace ClinicaOptica.Application.Interfaces
{
    /// <summary>
    /// Interfaz para el repositorio de usuarios
    /// </summary>
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Obtiene un usuario por ID
        /// </summary>
        /// <param name="id">ID del usuario</param>
        /// <returns>Usuario encontrado o null</returns>
        Task<Usuario?> GetByIdAsync(int id);

        /// <summary>
        /// Obtiene un usuario por nombre de usuario
        /// </summary>
        /// <param name="username">Nombre de usuario</param>
        /// <returns>Usuario encontrado o null</returns>
        Task<Usuario?> GetByUsernameAsync(string username);

        /// <summary>
        /// Verifica si existe un usuario con el nombre de usuario especificado
        /// </summary>
        /// <param name="username">Nombre de usuario a verificar</param>
        /// <param name="excludeId">ID a excluir de la búsqueda</param>
        /// <returns>True si existe</returns>
        Task<bool> ExistsByUsernameAsync(string username, int? excludeId = null);

        /// <summary>
        /// Crea un nuevo usuario
        /// </summary>
        /// <param name="usuario">Datos del usuario</param>
        /// <returns>Usuario creado</returns>
        Task<Usuario> CreateAsync(Usuario usuario);

        /// <summary>
        /// Actualiza un usuario existente
        /// </summary>
        /// <param name="usuario">Datos actualizados del usuario</param>
        /// <returns>Usuario actualizado</returns>
        Task<Usuario> UpdateAsync(Usuario usuario);

        /// <summary>
        /// Elimina un usuario
        /// </summary>
        /// <param name="id">ID del usuario a eliminar</param>
        /// <returns>True si se eliminó correctamente</returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// Obtiene todos los usuarios
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        Task<IEnumerable<Usuario>> GetAllAsync();

        /// <summary>
        /// Obtiene usuarios por rol
        /// </summary>
        /// <param name="rolId">ID del rol</param>
        /// <returns>Lista de usuarios con el rol especificado</returns>
        Task<IEnumerable<Usuario>> GetByRolAsync(int rolId);
    }
} 