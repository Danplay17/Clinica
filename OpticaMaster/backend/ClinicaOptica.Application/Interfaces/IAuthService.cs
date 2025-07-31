using ClinicaOptica.Application.DTOs;

namespace ClinicaOptica.Application.Interfaces
{
    /// <summary>
    /// Interfaz para el servicio de autenticación y autorización
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Autentica un usuario y genera un token JWT
        /// </summary>
        /// <param name="loginDto">Datos de login</param>
        /// <returns>Token JWT y datos del usuario</returns>
        Task<AuthResponseDto> LoginAsync(LoginDto loginDto);

        /// <summary>
        /// Registra un nuevo usuario (solo administradores)
        /// </summary>
        /// <param name="registerDto">Datos de registro</param>
        /// <returns>Datos del usuario creado</returns>
        Task<UsuarioDto> RegisterAsync(RegisterDto registerDto);

        /// <summary>
        /// Valida un token JWT
        /// </summary>
        /// <param name="token">Token a validar</param>
        /// <returns>True si el token es válido</returns>
        bool ValidateToken(string token);

        /// <summary>
        /// Obtiene el ID del usuario desde el token
        /// </summary>
        /// <param name="token">Token JWT</param>
        /// <returns>ID del usuario</returns>
        int GetUserIdFromToken(string token);
    }
} 