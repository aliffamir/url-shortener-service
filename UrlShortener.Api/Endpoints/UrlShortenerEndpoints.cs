using Microsoft.AspNetCore.Mvc;

using UrlShortener.Contracts.Dtos;
using UrlShortener.Core.UseCases;

namespace UrlShortener.Api.Endpoints;

public static class UrlShortenerEndpoints
{
    public static RouteGroupBuilder MapUrlShortenerEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/");

        // POST /shorten
        group.MapPost("shorten", async (CreateShortUrlRequest request, [FromServices] CreateShortUrlHandler handler, HttpContext context) =>
        {
            string domain = context.Request.Host.Value!;
            var response = await handler.HandleAsync(request with { Domain = domain });

            return response is null ? Results.InternalServerError() : Results.Ok(response);
        });


        // Get /{key}
        group.MapGet("{key}", async (string key, [FromServices] ResolveShortUrlHandler handler) =>
        {
            var response = await handler.HandleAsync(key);

            return response is null ? Results.NotFound() : Results.Redirect(response.LongUrl);
        });

        return group;
    }
}