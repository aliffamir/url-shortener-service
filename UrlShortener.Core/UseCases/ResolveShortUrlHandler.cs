using UrlShortener.Core.Entities;
using UrlShortener.Core.Interfaces;

namespace UrlShortener.Core.UseCases;

public class ResolveShortUrlHandler
{
    private readonly IShortUrlRepository _shortUrlRepository;

    public ResolveShortUrlHandler(IShortUrlRepository shortUrlRepository)
    {
        _shortUrlRepository = shortUrlRepository;
    }

    public async Task<ShortenedUrl?> HandleAsync(string key)
    {
        var shortUrl = await _shortUrlRepository.GetByKeyAsync(key);

        if (shortUrl is null)
        {
            return null;
        }

        if (shortUrl.ExpiresAt.UtcDateTime <= DateTimeOffset.UtcNow)
        {
            await _shortUrlRepository.DeleteAsync(shortUrl.Id);
            return null;
        }

        return shortUrl;
    }
}