using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using IAuthorizationService = AuthrorizationMicroservice.Infrastructure.Abstractions.Services.IAuthorizationService;

namespace AuthrorizationMicroservice.Infrastructure.Services;

public class AuthorizationService : IAuthorizationService
{
    public Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user, object resource,
        IEnumerable<IAuthorizationRequirement> requirements)
    {
        var authContext = 
    }

    public Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user, object resource, string policyName)
    {
        throw new NotImplementedException();
    }
}