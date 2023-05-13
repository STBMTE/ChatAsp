using Chat.Database;

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Chat.Repositories
{
    public class RepositoryAsync<T>: IRepositoryAsync<T> where T : class
    {
        protected readonly ChatContext _dbContext;

        protected RepositoryAsync(ChatContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> Entities => _dbContext.Set<T>();

        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity); //todo: не удалять а делать делете=1
            return Task.CompletedTask;
        }
        
        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null)
        {
            var result = _dbContext.Set<T>().AsNoTracking();
            if (expression != null)
                result = result.Where(expression); //todo: показывать все что не удалены - делете=1
            return result;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public Task UpdateAsync(T entity)
        {
            _dbContext.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
