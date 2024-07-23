using Autofac;
using Autofac.Configuration;
using Microsoft.AspNetCore.Diagnostics;
using UserMicroservice.Infrastructure.Data;
using UserMicroservice.Infrastructure.Data.Core;

namespace UserMicroservice.Modules;

public class DefaultInfrastructureModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        RegisterCommonDependencies(builder);
    }

    private void RegisterCommonDependencies(ContainerBuilder builder)
    {
        builder.RegisterType<ExceptionHandlerMiddleware>().AsSelf().InstancePerLifetimeScope();
        
        builder.Register(c =>
            {
                var config = c.Resolve<IConfiguration>();
            
                var context = new AppDbContext(config.GetConnectionString("Mongo"));
                return context;
            })
            .AsSelf()
            .As<IAppDbContext>()
            .InstancePerLifetimeScope();
        
        var module = new ConfigurationModule(GetConfiguration());
        builder.RegisterModule(module);
    }

    private static IConfiguration GetConfiguration()
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());

        builder.AddJsonFile("appsettings.json", true, true);

#if DEBUG
        builder.AddJsonFile("appsettings.Development.json", true, true);
#endif

        return builder.Build();
    }
}