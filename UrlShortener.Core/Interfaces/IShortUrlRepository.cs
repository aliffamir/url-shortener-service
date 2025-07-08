using UrlShortener.Core.Entities;

namespace UrlShortener.Core.Interfaces;

public interface IShortUrlRepository
{
    Task<ShortenedUrl?> CreateAsync(ShortenedUrl shortenedUrl);
    Task<ShortenedUrl?> GetByKeyAsync(string key); 
}