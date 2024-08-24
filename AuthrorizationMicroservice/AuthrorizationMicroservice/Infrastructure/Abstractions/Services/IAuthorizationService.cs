using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace AuthrorizationMicroservice.Infrastructure.Abstractions.Services;

public interface IAuthorizationService
{
    Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user, object resource,
        IEnumerable<IAuthorizationRequirement> requirements);

    Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user, object resource, string policyName);
}