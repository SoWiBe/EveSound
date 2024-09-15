using Autofac;
using Microsoft.Extensions.Options;

namespace Facade.Extensions;

public static class AutoFacExtension
{
    public static void AddHttpClientFactory(this ContainerBuilder builder)
    {
        builder.Register(_ =>
        {
            var services = new ServiceCollection();
            services.AddHttpClient(Options.DefaultName, c =>
            {
                // ...
            }).ConfigurePrimaryHttpMessageHandler(() =>
            {
                return new HttpClientHandler
                {
                    ClientCertificateOptions = ClientCertificateOption.Manual,
                    ServerCertificateCustomValidationCallback =
                        (httpRequestMessage, cert, certChain, policyErrors) => true
                };
            });
            var provider = services.BuildServiceProvider();
            return provider.GetRequiredService<IHttpClientFactory>();
        }).AsSelf().As<IHttpClientFactory>();
    }
}