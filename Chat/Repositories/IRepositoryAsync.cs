using System.Linq.Expressions;

namespace Chat.Repositories
{
    public interface IRepositoryAsync<T>
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        
        Task<T> GetByIdAsync(int id);

        IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null);
        IQueryable<T> Entities { get; }
    }
}