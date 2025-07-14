using UrlShortener.Contracts.Mappers;
using UrlShortener.Contracts.Dtos;
using UrlShortener.Core.Interfaces;

public class ResolveShortUrlHandler {
    private readonly IShortUrlRepository _shortUrlRepository;

    public ResolveShortUrlHandler (IShortUrlRepository shortUrlRepository) {
        _shortUrlRepository = shortUrlRepository;
    }

    public async Task<ShortUrlResponse?> HandleAsync(string key) {
       var shortUrl = await _shortUrlRepository.GetByKeyAsync(key);

        return shortUrl is null ? null : shortUrl.ToDto();
    }
}