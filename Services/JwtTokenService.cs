using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InvoiceManagement.Services
{
    public class JwtTokenService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<JwtTokenService> _logger;

        public JwtTokenService(IConfiguration configuration, ILogger<JwtTokenService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public string GenerateToken(string userId, string userRole)
        {
            var jwtSettings = _configuration.GetSection("Jwt");

            var key = jwtSettings["Key"] ?? throw new ArgumentNullException("JWT Key cannot be null");
            var issuer = jwtSettings["Issuer"] ?? throw new ArgumentNullException("JWT Issuer cannot be null");
            var audience = jwtSettings["Audience"] ?? throw new ArgumentNullException("JWT Audience cannot be null");
            var duration = jwtSettings["DurationInMinutes"] ?? throw new ArgumentNullException("JWT Duration cannot be null");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(ClaimTypes.Role, userRole),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(double.Parse(duration)),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
