using Microsoft.EntityFrameworkCore;

using UrlShortener.Core.Interfaces;
using UrlShortener.Infrastructure.Data;
using UrlShortener.Infrastructure.Repositories;

namespace UrlShortener.Infrastructure;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
             options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
        )
        .AddScoped<IShortUrlRepository, EfShortUrlRepository>();

        return services;
    }
}