using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Mok.WebAPI.Controllers
{

    /// <summary>
    /// Controlador para la autenticación de usuarios y generación de tokens JWT.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor de AuthController
        /// </summary>
        /// <param name="configuration"></param>
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Maneja las solicitudes de inicio de sesión y genera un token JWT válido.
        /// </summary>
        /// <param name="username">Nombre de usuario.</param>
        /// <param name="password">Contraseña del usuario.</param>
        /// <returns>Token JWT generado.</returns>
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(string username, string password)
        {
            // Aquí deberías validar las credenciales del usuario.
            // Por simplicidad, asumiremos que las credenciales son válidas.

            var token = GenerateJwtToken(username);
            return Ok(new { token });
        }

        /// <summary>
        /// Genera un token JWT con el nombre de usuario como claim.
        /// </summary>
        /// <param name="username">Nombre de usuario.</param>
        /// <returns>Token JWT generado.</returns>
        private string GenerateJwtToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["AppSettings:SecretKey"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                // Set the audience claim
                Audience = "MOK_API", // Set it to the value specified in ValidAudience
                Issuer = "MOK" // Set it to the value specified in ValidIssuer
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
