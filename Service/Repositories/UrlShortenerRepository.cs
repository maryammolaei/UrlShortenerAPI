using Microsoft.EntityFrameworkCore;
using UrlShortener.Data;
using UrlShortener.Models;

namespace UrlShortener.Service.Repositories
{
    public class UrlShortenerRepository:Repository<UrlManagement>, IUrlShortenerRepository
    {
        public UrlShortenerRepository(UrlShortenetContext context) : base(context)
        {
        }

        public async Task<string> GetLongUrl(string shortUrl)
        { 
            var shortUrlEntity = await _DbSet.FirstOrDefaultAsync(s => s.ShortUrl.Trim() == shortUrl.Trim());
            return shortUrlEntity?.Url;
        }
    }
}
