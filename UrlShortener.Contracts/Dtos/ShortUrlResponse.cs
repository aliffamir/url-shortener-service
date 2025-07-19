namespace UrlShortener.Contracts.Dtos;

public record class ShortUrlResponse(
        string LongUrl,
        string ShortUrl,
        string Key,
        DateTimeOffset CreatedAt,
        DateTimeOffset ExpiresAt);