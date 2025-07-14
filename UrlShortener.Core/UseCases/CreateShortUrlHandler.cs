using UrlShortener.Contracts.Dtos;
using UrlShortener.Core.Interfaces;

namespace UrlShortener.Core.UseCases;

public class CreateShortUrlHandler  {
    private readonly IShortUrlRepository _shortUrlRepository;
    
    public CreateShortUrlHandler(IShortUrlRepository shortUrlRepository) {
        _shortUrlRepository = shortUrlRepository;
    }
    
    // TODO: refactor using Result pattern
    // public async Task<ShortUrlResponse> HandleAsync(CreateShortUrlRequest shortUrlRequest) {
    //
    // }

}