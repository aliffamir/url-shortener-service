using UrlShortener.Contracts.Dtos;
using UrlShortener.Core.Entities;
using UrlShortener.Core.Interfaces;
using UrlShortener.Core.Helpers;

namespace UrlShortener.Core.UseCases;

public class CreateShortUrlHandler
{
    private readonly IShortUrlRepository _shortUrlRepository;

    public CreateShortUrlHandler(IShortUrlRepository shortUrlRepository)
    {
        _shortUrlRepository = shortUrlRepository;
    }

    // TODO: refactor using Result pattern
    public async Task<ShortenedUrl?> HandleAsync(CreateShortUrlRequest shortUrlRequest)
    {
        var expiresAtUtc = shortUrlRequest.ExpiresAt.UtcDateTime;
        if (expiresAtUtc <= DateTime.UtcNow) {
            return null;
        }

        var shortKey = UrlShortenerHelper.GenerateShortKey(shortUrlRequest.LongUrl);
        string shortUrl = $"{shortUrlRequest.Domain}/{shortKey}";

        var shortUrlEntity = new ShortenedUrl
        {
            LongUrl = shortUrlRequest.LongUrl,
            Key = shortKey,
            ShortUrl = shortUrl,
            ExpiresAt = expiresAtUtc,
        };

        await _shortUrlRepository.CreateAsync(shortUrlEntity);
        return shortUrlEntity;
    }
}