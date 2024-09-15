using AuthrorizationMicroservice.Infrastructure.Abstractions.Services;
using AuthrorizationMicroservice.Infrastructure.Services;
using Autofac;

namespace AuthrorizationMicroservice.Infrastructure;

public class DefaultInfrastructureModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<AuthorizationService>().As<IAuthorizationService>();
    }
}