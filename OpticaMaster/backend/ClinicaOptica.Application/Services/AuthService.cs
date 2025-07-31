using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using ClinicaOptica.Application.Interfaces;
using ClinicaOptica.Application.DTOs;
using ClinicaOptica.Domain.ClasesOptica;
using ClinicaOptica.Application.Mappings;
using AutoMapper;

namespace ClinicaOptica.Application.Services
{
    /// <summary>
    /// Servicio para la autenticación y autorización
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthService(IUsuarioRepository usuarioRepository, IConfiguration configuration, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
            _mapper = mapper;
        }

        /// <summary>
        /// Autentica un usuario y genera un token JWT
        /// </summary>
        public async Task<AuthResponseDto> LoginAsync(LoginDto loginDto)
        {
            // Buscar usuario por nombre de usuario
            var usuario = await _usuarioRepository.GetByUsernameAsync(loginDto.Username);
            if (usuario == null)
                throw new UnauthorizedAccessException("Credenciales inválidas");

            // Verificar contraseña
            if (!VerifyPassword(loginDto.Password, usuario.PasswordHash))
                throw new UnauthorizedAccessException("Credenciales inválidas");

            // Generar token JWT
            var token = GenerateJwtToken(usuario);
            var expiration = DateTime.UtcNow.AddHours(24);

            // Mapear a DTO
            var usuarioDto = _mapper.Map<UsuarioDto>(usuario);

            return new AuthResponseDto
            {
                Token = token,
                Expiration = expiration,
                Usuario = usuarioDto
            };
        }

        /// <summary>
        /// Registra un nuevo usuario (solo administradores)
        /// </summary>
        public async Task<UsuarioDto> RegisterAsync(RegisterDto registerDto)
        {
            // Verificar si el nombre de usuario ya existe
            if (await _usuarioRepository.ExistsByUsernameAsync(registerDto.Username))
                throw new InvalidOperationException("El nombre de usuario ya existe");

            // Crear hash de la contraseña
            var passwordHash = HashPassword(registerDto.Password);

            // Crear nuevo usuario
            var usuario = new Usuario
            {
                Username = registerDto.Username,
                PasswordHash = passwordHash,
                RolId = registerDto.RolId
            };

            // Guardar en base de datos
            var usuarioCreado = await _usuarioRepository.CreateAsync(usuario);

            // Mapear a DTO
            return _mapper.Map<UsuarioDto>(usuarioCreado);
        }

        /// <summary>
        /// Valida un token JWT
        /// </summary>
        public bool ValidateToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:SecretKey"]!);

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _configuration["JwtSettings:Issuer"],
                    ValidAudience = _configuration["JwtSettings:Audience"],
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Obtiene el ID del usuario desde el token
        /// </summary>
        public int GetUserIdFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            var userIdClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                throw new InvalidOperationException("Token inválido");

            return int.Parse(userIdClaim.Value);
        }

        /// <summary>
        /// Genera un token JWT
        /// </summary>
        private string GenerateJwtToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:SecretKey"]!);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Username),
                new Claim(ClaimTypes.Role, usuario.Rol?.Nombre ?? "Usuario")
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["JwtSettings:Issuer"],
                Audience = _configuration["JwtSettings:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// Genera hash de la contraseña
        /// </summary>
        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }

        /// <summary>
        /// Verifica la contraseña
        /// </summary>
        private bool VerifyPassword(string password, string hash)
        {
            var hashedPassword = HashPassword(password);
            return hashedPassword == hash;
        }
    }
} 