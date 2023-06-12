using UrlShortener.Models;

namespace UrlShortener.Service
{
    public interface IRepository<T>
        where T :  BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> Get(int id);
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<int> GetMaxId();
    }
}
