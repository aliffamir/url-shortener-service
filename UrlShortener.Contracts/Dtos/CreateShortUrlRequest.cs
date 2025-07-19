namespace UrlShortener.Contracts.Dtos;

public record class CreateShortUrlRequest(
        string LongUrl,
        string Domain,
        DateTime ExpiresAt);