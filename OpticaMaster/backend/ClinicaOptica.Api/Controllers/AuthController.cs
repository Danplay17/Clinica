using Microsoft.AspNetCore.Mvc;
using ClinicaOptica.Application.Interfaces;
using ClinicaOptica.Application.DTOs;

namespace ClinicaOptica.Api.Controllers
{
    /// <summary>
    /// Controlador para la autenticación y autorización
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Autentica un usuario y genera un token JWT
        /// </summary>
        /// <param name="loginDto">Datos de login</param>
        /// <returns>Token JWT y datos del usuario</returns>
        [HttpPost("login")]
        [ProducesResponseType(typeof(AuthResponseDto), 200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                var response = await _authService.LoginAsync(loginDto);
                return Ok(response);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Registra un nuevo usuario (solo administradores)
        /// </summary>
        /// <param name="registerDto">Datos de registro</param>
        /// <returns>Datos del usuario creado</returns>
        [HttpPost("register")]
        [ProducesResponseType(typeof(UsuarioDto), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                var usuario = await _authService.RegisterAsync(registerDto);
                return CreatedAtAction(nameof(Register), usuario);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Valida un token JWT
        /// </summary>
        /// <param name="token">Token a validar</param>
        /// <returns>True si el token es válido</returns>
        [HttpPost("validate")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult ValidateToken([FromBody] string token)
        {
            try
            {
                var isValid = _authService.ValidateToken(token);
                return Ok(new { isValid });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
} 