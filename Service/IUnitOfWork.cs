namespace UrlShortener.Service
{
    public interface IUnitOfWork
    {
        IUrlShortenerRepository UrlShortenerRepository { get; }
        Task Commit();
    }
}
