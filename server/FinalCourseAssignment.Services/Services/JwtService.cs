using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using FinalCourseAssignment.Domain;
using FinalCourseAssignment.Domain.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Data;

namespace FinalCourseAssignment.Services.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings _settings;
        private readonly IDateTimeProvider _dateTimeProvider;

        public JwtService(IOptions<JwtSettings> settings, IDateTimeProvider dateTimeProvider)
        {
            _settings = settings.Value;
            _dateTimeProvider = dateTimeProvider;
        }

        public string GenerateJsonWebToken(Guid userId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = [
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
                ];

            var token = new JwtSecurityToken(
                claims: claims,
                audience: _settings.Audience,
                issuer: _settings.Issuer,
                expires: _dateTimeProvider.GetNow().Add(TimeSpan.FromMinutes(_settings.ExpirationInMinutes)),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

