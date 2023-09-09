﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TodoistClone.Application.Common.Interfaces.Authentication;
using TodoistClone.Application.Common.Interfaces.Services;

namespace TodoistClone.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public JwtTokenGenerator(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public string GenerateToken(Guid userId, string firstName, string lastName) 
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("extremely-secret-key-that-no-one-knows")),
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, firstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var securityToken = new JwtSecurityToken(
                claims: claims, signingCredentials: signingCredentials, issuer: "TodoistClone",
                expires: _dateTimeProvider.UtcNow.AddMinutes(60));

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
