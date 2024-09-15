using AuthrorizationMicroservice.Infrastructure.Abstractions.Services;
using Grpc.Core;

namespace AuthrorizationMicroservice.Services;

public class Authorization : AuthrorizationMicroservice.Authorization.AuthorizationBase
{
    private readonly IAuthorizationService _authorizationService;

    public Authorization(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }
    
    public override async Task<AuthorizeReply> Authorize(AuthorizeRequest request, ServerCallContext context)
    {
        var result = await _authorizationService.AuthorizeAsync();
        return await Task.FromResult(new AuthorizeReply
        {
            Message = result.ToString()
        });
    }

    public override Task<RegistrationReply> Registration(RegistrationRequest request, ServerCallContext context)
    {
        return base.Registration(request, context);
    }
}