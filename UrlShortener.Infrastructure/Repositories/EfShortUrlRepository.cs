
using UrlShortener.Core.Entities;
using UrlShortener.Core.Interfaces;

namespace UrlShortener.Infrastructure.Repositories;

public class EfShortUrlRepository : IShortUrlRepository
{
    public Task<ShortenedUrl?> CreateAsync(ShortenedUrl shortenedUrl)
    {
        throw new NotImplementedException();
    }

    public Task<ShortenedUrl?> GetByKeyAsync(string key)
    {
        throw new NotImplementedException();
    }
}