using Microsoft.EntityFrameworkCore;
using ClinicaOptica.Domain.ClasesOptica;
using ClinicaOptica.Application.Interfaces;

namespace ClinicaOptica.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio para la gestión de usuarios
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly OpticaDbContext _context;

        public UsuarioRepository(OpticaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene un usuario por ID
        /// </summary>
        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuarios
                .Include(u => u.Rol)
                .Include(u => u.Optometrista)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        /// <summary>
        /// Obtiene un usuario por nombre de usuario
        /// </summary>
        public async Task<Usuario?> GetByUsernameAsync(string username)
        {
            return await _context.Usuarios
                .Include(u => u.Rol)
                .Include(u => u.Optometrista)
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        /// <summary>
        /// Verifica si existe un usuario con el nombre de usuario especificado
        /// </summary>
        public async Task<bool> ExistsByUsernameAsync(string username, int? excludeId = null)
        {
            var query = _context.Usuarios.Where(u => u.Username == username);
            
            if (excludeId.HasValue)
                query = query.Where(u => u.Id != excludeId.Value);

            return await query.AnyAsync();
        }

        /// <summary>
        /// Crea un nuevo usuario
        /// </summary>
        public async Task<Usuario> CreateAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        /// <summary>
        /// Actualiza un usuario existente
        /// </summary>
        public async Task<Usuario> UpdateAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        /// <summary>
        /// Elimina un usuario
        /// </summary>
        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return false;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Obtiene todos los usuarios
        /// </summary>
        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios
                .Include(u => u.Rol)
                .Include(u => u.Optometrista)
                .OrderBy(u => u.Username)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene usuarios por rol
        /// </summary>
        public async Task<IEnumerable<Usuario>> GetByRolAsync(int rolId)
        {
            return await _context.Usuarios
                .Include(u => u.Rol)
                .Include(u => u.Optometrista)
                .Where(u => u.RolId == rolId)
                .OrderBy(u => u.Username)
                .ToListAsync();
        }
    }
} 