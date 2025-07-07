namespace UrlShortener.Core.Entities;

public class ShortenedUrl
{
    public Guid Id { get; set; }
    public required string LongUrl { get; set; }
    public required string ShortUrl { get; set; }
    public required string Key { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ExpiresAt { get; set; }
}