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
    
    public override Task<AuthorizeReply> Authorize(AuthorizeRequest request, ServerCallContext context)
    {
        return Task.FromResult(new AuthorizeReply
        {
            Message = "Ная, я тебя люблю!"
        });
    }

    public override Task<RegistrationReply> Registration(RegistrationRequest request, ServerCallContext context)
    {
        return base.Registration(request, context);
    }
}