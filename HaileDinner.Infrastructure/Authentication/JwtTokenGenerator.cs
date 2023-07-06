using HaileDinner.Application.Common.Interfaces.Authentication;
using HaileDinner.Application.Common.Services;
using HaileDinner.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HaileDinner.infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions)
    {
        _dateTimeProvider = dateTimeProvider;
        _jwtSettings = jwtOptions.Value;
    }

    public string GenerateToken(User user)
    {
        var signingCredential = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256 );

        var claims = new[]{
            new Claim(JwtRegisteredClaimNames.Sub,user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName,user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName,user.LastName),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()), 
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.Expiration),
            claims: claims,
            signingCredentials: signingCredential
            );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}