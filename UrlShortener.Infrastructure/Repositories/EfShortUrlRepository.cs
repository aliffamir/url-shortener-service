using Microsoft.EntityFrameworkCore;

using UrlShortener.Core.Entities;
using UrlShortener.Core.Interfaces;
using UrlShortener.Infrastructure.Data;
namespace UrlShortener.Infrastructure.Repositories;

public class EfShortUrlRepository : IShortUrlRepository
{
    private readonly AppDbContext _context;
    public EfShortUrlRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ShortenedUrl?> CreateAsync(ShortenedUrl shortenedUrl)
    {
        _context.ShortenedUrls.Add(shortenedUrl);
        await _context.SaveChangesAsync();

        return shortenedUrl;
    }

    public async Task<ShortenedUrl?> DeleteAsync(int id)
    {
        var shortUrl = await _context.ShortenedUrls
            .AsNoTracking()
            .SingleOrDefaultAsync(url => url.Id == id);

        if (shortUrl is null) {
            return null;
        }

        _context.ShortenedUrls.Remove(shortUrl);
        await _context.SaveChangesAsync();
        return shortUrl;
    }

    public async Task<ShortenedUrl?> GetByKeyAsync(string key)
    {
        var shortUrl = await _context.ShortenedUrls
            .AsNoTracking()
            .SingleOrDefaultAsync(url => url.Key == key);


        return (shortUrl is null) ? null : shortUrl;
    }

    public async Task<bool> KeyExists(string key)
    {
        return await _context.ShortenedUrls
            .AsNoTracking()
            .AnyAsync(url => url.Key == key);
    }
}