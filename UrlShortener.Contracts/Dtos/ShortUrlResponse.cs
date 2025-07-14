namespace UrlShortener.Contracts.Dtos;

public record class ShortUrlResponse(
        string LongUrl,
        string ShortUrl,
        string Key,
        DateTime CreatedAt,
        DateTime ExpiresAt);