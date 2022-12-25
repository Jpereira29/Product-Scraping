using System.Linq.Expressions;

namespace Product_Scraping.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        Task<T> GetByCode(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
    }
}
