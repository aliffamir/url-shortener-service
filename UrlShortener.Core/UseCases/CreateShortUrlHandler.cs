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
    public async Task<ShortenedUrl> HandleAsync(CreateShortUrlRequest shortUrlRequest, string domainName)
    {
        var shortKey = UrlShortenerHelper.GenerateShortKey(shortUrlRequest.LongUrl);
        string shortUrl = $"{domainName}/{shortKey}";

        var shortUrlEntity = new ShortenedUrl
        {
            LongUrl = shortUrlRequest.LongUrl,
            Key = shortKey,
            ShortUrl = shortUrl,
            // TODO: accept expiry
            ExpiresAt = DateTime.UtcNow.AddYears(1)
        };

        await _shortUrlRepository.CreateAsync(shortUrlEntity);
        return shortUrlEntity;
    }
}