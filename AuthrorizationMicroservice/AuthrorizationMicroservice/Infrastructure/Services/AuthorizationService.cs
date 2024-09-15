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
    
    public Task<SecurityToken> AuthorizeAsync()
    {
        var handler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("asld;ifhllhlkjjhsdlkjafhl8467584");
        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity() {Claims = {}},
            Expires = DateTime.UtcNow.AddMinutes(15),
            SigningCredentials = credentials,
        };

        var token = handler.CreateToken(tokenDescriptor);

        return Task.FromResult(token);
    }
}