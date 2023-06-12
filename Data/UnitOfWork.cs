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
        public async Task<bool> Commit()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex) 
            {
                return false;
            }

        }
    }
}
