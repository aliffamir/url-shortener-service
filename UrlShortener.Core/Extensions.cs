using UrlShortener.Core.UseCases;

namespace UrlShortener.Core;

public static class CoreExtensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddTransient<CreateShortUrlHandler>();

        return services;
    }
}