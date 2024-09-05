using Autofac;
using Facade.Abstractions.Repositories;
using Facade.Infrastructure.Repositories;

namespace Facade.Infrastructure;

public class DefaultInfrastructureModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        RegisterCommonDependencies(builder);
    }
    
    private void RegisterCommonDependencies(ContainerBuilder builder)
    {
        builder.RegisterType<ApiRepository>().As<IApiRepository>();
        builder.RegisterType<JsonRepository>().As<IJsonRepository>();
    }
}