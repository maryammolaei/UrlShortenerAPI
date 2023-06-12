using UrlShortener.Models;

namespace UrlShortener.Service
{
    public interface IUrlShortenerRepository : IRepository<UrlManagement>
    {
        Task<string> GetLongUrl (string shortUrl);
    }
}
