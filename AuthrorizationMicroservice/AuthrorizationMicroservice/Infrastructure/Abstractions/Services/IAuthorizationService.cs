using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace AuthrorizationMicroservice.Infrastructure.Abstractions.Services;

public interface IAuthorizationService
{
    Task<JwtSecurityToken> AuthorizeAsync(ClaimsPrincipal user, object resource,
        IEnumerable<IAuthorizationRequirement> requirements);
}