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
            var shortUrlEntity = await _DbSet.FirstOrDefaultAsync(s => s.ShortUrl.Trim().Equals(shortUrl.Trim()));
            return shortUrlEntity?.Url;
        }

        public async Task<UrlManagement> GetByUrl(string url)
        {
            return await _DbSet.FirstOrDefaultAsync(s => s.Url.Trim() == url.Trim());
        }

        public async Task<(bool isSucceeded, string shortUrl)> AddUrl(UrlManagement entity)
        {
            UrlManagement urlManagement = await GetByUrl(entity.Url);
            if (urlManagement != null)
                return (true, urlManagement?.ShortUrl);
            try
            {
                await _DbSet.AddAsync(entity);
                return (true, string.Empty);
            }
            catch (Exception e)
            {
                return (false, string.Empty);

            }
        }
    }
}
