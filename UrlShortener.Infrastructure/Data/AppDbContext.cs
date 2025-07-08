using Microsoft.EntityFrameworkCore;

namespace UrlShortener.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
}