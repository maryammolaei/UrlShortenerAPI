using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Data;
using UrlShortener.Models;

namespace UrlShortener.Service.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected UrlShortenetContext _Context;
        protected DbSet<T> _DbSet;
        public Repository(UrlShortenetContext context)
        {
            _Context = context;
            _DbSet = _Context.Set<T>();
        }

        public virtual async Task<bool> Add(T entity)
        {
            try
            {
                await _DbSet.AddAsync(entity);
                return true;
            }
            catch (Exception e)
            {
                return false;

            }
        }

        public virtual async Task<bool> Delete(T entity)
        {
            try
            {
                _DbSet.Remove(entity);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _DbSet.ToListAsync();
        }

        public virtual async Task<T?> Get(int id)
        {
            return await _DbSet.FindAsync(id);
        }

        public virtual async Task<bool> Update(T entity)
        {
            try
            {
                _DbSet.Update(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<int> GetMaxId() => await _DbSet.MaxAsync(e => e.Id);
    }
}
