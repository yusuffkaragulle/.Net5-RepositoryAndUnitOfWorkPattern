using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RepositoryAndUnitOfWorkPattern.Data.Repositories
{
    public interface IRepository<T> : IDisposable where T : class, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(Guid id);
        Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        Task AddAsync(T entity);
        void Update(T entity);
        void DeleteAsync(Guid id);
        void Delete(T entity);
    }
}
