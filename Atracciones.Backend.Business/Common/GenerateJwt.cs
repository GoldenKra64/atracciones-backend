using Atracciones.Backend.Business.DTOs;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Common
{
    public static class GenerateJwt
    {
        public static (string Token, DateTime Expiration) GenerateJwtToken(JwtSettings _jwtSettings, string username, IEnumerable<string> roles)
        {
            Console.WriteLine($"Generating JWT for user: {username} with roles: {string.Join(", ", roles)}, {_jwtSettings}, {_jwtSettings.SecretKey}");
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // Roles
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

            var expiration = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationMinutes);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return (tokenString, expiration);
        }
    }
}
