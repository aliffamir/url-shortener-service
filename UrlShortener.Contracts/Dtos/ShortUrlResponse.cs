namespace UrlShortener.Contracts.Dtos;

public record class ShortUrlResponse(
        Guid Id,
        string LongUrl,
        string ShortUrl,
        string Key,
        DateTime CreatedAt,
        DateTime ExpiresAt);