using UrlShortener.Contracts.Dtos;
using UrlShortener.Core.Entities;

namespace UrlShortener.Api.Mappers;

public static class ShortUrlMapping
{
    public static ShortUrlResponse ToDto(this ShortenedUrl shortUrl)
    {
        return new(
                shortUrl.LongUrl,
                shortUrl.ShortUrl,
                shortUrl.Key,
                shortUrl.CreatedAt,
                shortUrl.ExpiresAt
                );
    }
}