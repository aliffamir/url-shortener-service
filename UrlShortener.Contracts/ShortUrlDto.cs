namespace UrlShortener.Contracts;

public record class ShortUrlDto(
        Guid Id,
        string LongUrl,
        string ShortUrl,
        string Key,
        DateTime CreatedAt,
        DateTime ExpiresAt);