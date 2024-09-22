using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace AuthrorizationMicroservice.Infrastructure.Abstractions.Services;

public interface IAuthorizationService
{
    Task<SecurityToken> AuthorizeAsync();
}