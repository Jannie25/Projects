using Euromonitor.JWTHelper.Interfaces;
using Euromonitor.JWTHelper.Models;
using Euromonitor.Models.General;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Euromonitor.JWTHelper.Services
{
    public class JwtService : IJWTService
    {
        private readonly JWTConfig _jwtConfig;

        public JwtService(IOptions<JWTConfig> jwtConfig)
        {
            _jwtConfig = jwtConfig.Value;
        }

        public string GenerateSecurityToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("FirstName", user.FirstName),
                    new Claim("LastName", user.LastName),
                    new Claim("Username", user.Username),
                    new Claim("Email", user.EMail)
                }),
                Expires = DateTime.UtcNow.AddMinutes(System.Convert.ToDouble(_jwtConfig.ExpirationInMinutes)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
