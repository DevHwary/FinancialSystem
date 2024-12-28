using FinSystem.Application.Interfaces;
using FinSystem.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace FinSystem.Application.Services
{
    public class JwtHandler : IJwtHandler
    {
        private readonly string _jwtKey;
        private readonly string _issuer;
        private readonly string _audience;

        public JwtHandler(string jwtKey, string issuer, string audience)
        {
            _jwtKey = jwtKey;
            _issuer = issuer;
            _audience = audience;
        }

        public string CreateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        };

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(3),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
