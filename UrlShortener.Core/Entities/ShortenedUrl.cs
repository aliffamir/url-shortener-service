namespace UrlShortener.Core.Entities;

public class ShortenedUrl
{
    public int Id { get; set; }
    public required string LongUrl { get; set; }
    public required string ShortUrl { get; set; }
    // TODO: maybe make this the pk for more efficient querying
    public required string Key { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime ExpiresAt { get; set; }
}