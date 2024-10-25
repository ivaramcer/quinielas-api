using Microsoft.EntityFrameworkCore;
using QuinielasApi.IRepository.Configuration;
using System.Linq.Expressions;
using QuinielasApi.DBContext;
using EFCore.BulkExtensions;

namespace QuinielasApi.Repository.Configuration
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DatabaseContext RepositoryContext { get; set; }
        public RepositoryBase(DatabaseContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        public IQueryable<T> FindAll() => RepositoryContext.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);
        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);
        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);

        public async Task BulkInsertAsync(List<T> entities)
        {
            await RepositoryContext.BulkInsertAsync(entities, options =>
            {
                options.SetOutputIdentity = true;
            });
        }

        public async Task BulkUpdateAsync(List<T> entities)
        {
            await RepositoryContext.BulkUpdateAsync(entities, options =>
            {
                options.SetOutputIdentity = true;
            });
        }
    }
}
