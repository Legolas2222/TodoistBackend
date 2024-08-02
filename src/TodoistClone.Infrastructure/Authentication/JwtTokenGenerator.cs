using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TodoistClone.Application.Common.Interfaces.Authentication;
using TodoistClone.Application.Common.Interfaces.Services;
using TodoistClone.Domain.Entities;

namespace TodoistClone.Infrastructure.Authentication
{
    public class JwtTokenGenerator(IDateTimeProvider dateTimeProvider) : IJwtTokenGenerator
    {
        private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;

        public string GenerateToken(User user)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("extremely-secret-key-that-no-one-knows")),
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var securityToken = new JwtSecurityToken(
                claims: claims, signingCredentials: signingCredentials, issuer: "TodoistClone",
                expires: _dateTimeProvider.UtcNow.AddMinutes(60));

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
