using UrlShortener.Models;

namespace UrlShortener.Service
{
    public interface IUrlShortenerRepository : IRepository<UrlManagement>
    {
        Task<string> GetLongUrl (string shortUrl);
        Task<UrlManagement> GetByUrl(string url);
        Task<(bool isSucceeded, string shortUrl)> AddUrl(UrlManagement entity);
    }
}
