namespace UrlShortener.Contracts.Dtos;

public record class CreateShortUrlDto(string LongUrl, DateTimeOffset ExpiresAt);