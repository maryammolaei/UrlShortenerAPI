using UrlShortener.Service;
using UrlShortener.Service.Repositories;

namespace UrlShortener.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUrlShortenerRepository UrlShortenerRepository { get; private set; }
        private readonly UrlShortenetContext _context;

        public UnitOfWork(UrlShortenetContext context)
        {
            _context = context;
            UrlShortenerRepository = new UrlShortenerRepository(_context);
        }
        public async Task Commit()
        {
            await _context.SaveChangesAsync();

        }
    }
}
