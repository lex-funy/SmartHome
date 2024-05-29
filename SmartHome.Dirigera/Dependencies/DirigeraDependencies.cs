using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartHome.Dirigera.Repositories;

namespace SmartHome.Dirigera.Dependencies;

public static class DirigeraDependencies
{
    public static IServiceCollection AddDirigera(this IServiceCollection services, IConfiguration configuration)
    {
        // Repositories
        services.AddSingleton<IDeviceRepository, DeviceRepository>();
        services.AddSingleton<ILightRepository, LightRepository>();

        var baseUrl =
            Environment.GetEnvironmentVariable("Dirigera__BaseUrl") ??
            throw new Exception("Environment variable Dirigera__BaseUrl is missing");
        
        var bearerToken =
            Environment.GetEnvironmentVariable("Dirigera__BearerToken") ??
            throw new Exception("Environment variable Dirigera__BearerToken is missing");

        services.AddSingleton<IFlurlClientCache>(_ => new FlurlClientCache()
            .WithDefaults(builder =>
                builder
                    .ConfigureInnerHandler(hch =>
                        hch.ServerCertificateCustomValidationCallback = (_, _, _, _) => true))
            .Add("DirigeraClient", baseUrl, builder =>
                // Add authorization bearer
                builder.WithHeader("Authorization", $"Bearer {bearerToken}")));

        return services;
    }
}