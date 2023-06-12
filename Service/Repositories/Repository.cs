using Microsoft.EntityFrameworkCore;
using UrlShortener.Data;

namespace UrlShortener.Service.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected UrlShortenetContext _Context;
        protected DbSet<T> _DbSet;
        public Repository(UrlShortenetContext context)
        {
            _Context = context;
            _DbSet = _Context.Set<T>();
        }

        public async Task<bool> Add(T entity)
        {
            try
            {
                await _DbSet.AddAsync(entity);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Delete(T entity)
        {
            try
            {
                _DbSet.Remove(entity);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _DbSet.ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await _DbSet.FindAsync(id);
        }

        public async Task<bool> Update(T entity)
        {
            try
            {
                _DbSet.Update(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
