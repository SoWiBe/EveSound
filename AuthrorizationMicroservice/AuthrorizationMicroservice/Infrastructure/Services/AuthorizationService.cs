using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using IAuthorizationService = AuthrorizationMicroservice.Infrastructure.Abstractions.Services.IAuthorizationService;

namespace AuthrorizationMicroservice.Infrastructure.Services;

public class AuthorizationService : IAuthorizationService
{
    private readonly IConfiguration _configuration;

    public AuthorizationService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public Task<JwtSecurityToken> AuthorizeAsync(ClaimsPrincipal user, object resource,
        IEnumerable<IAuthorizationRequirement> requirements)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, ""),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds
        );

        return Task.FromResult(token);
    }
}