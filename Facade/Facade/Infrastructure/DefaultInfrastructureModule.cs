using Autofac;
using Facade.Abstractions.Repositories;
using Facade.Abstractions.Services.Music;
using Facade.Extensions;
using Facade.Infrastructure.Repositories;
using Facade.Infrastructure.Services.Music;

namespace Facade.Infrastructure;

public class DefaultInfrastructureModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        RegisterCommonDependencies(builder);
    }
    
    private void RegisterCommonDependencies(ContainerBuilder builder)
    {
        builder.AddHttpClientFactory();
        builder.RegisterType<ApiRepository>().As<IApiRepository>();
        builder.RegisterType<JsonRepository>().As<IJsonRepository>();
        builder.RegisterType<MusicService>().As<IMusicService>();
    }
}