using Microsoft.AspNetCore.Authorization;

namespace AuthrorizationMicroservice.Infrastructure.Abstractions.Services;

public interface IAuthorizationHandler
{
    Task HandleAsync(AuthorizationHandlerContext context);
}