using AuthrorizationMicroservice.Infrastructure.Abstractions.Services;
using Grpc.Core;

namespace AuthrorizationMicroservice.Endpoints;

public class Authorization : AuthrorizationMicroservice.Authorization.AuthorizationBase
{
    private readonly IAuthorizationService _authorizationService;

    public Authorization(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }
    
    public override Task<AuthorizeReply> Authorize(AuthorizeRequest request, ServerCallContext context)
    {
        return base.Authorize(request, context);
    }

    public override Task<RegistrationReply> Registration(RegistrationRequest request, ServerCallContext context)
    {
        return base.Registration(request, context);
    }
}