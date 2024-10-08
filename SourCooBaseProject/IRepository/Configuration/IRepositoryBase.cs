﻿using System.Linq.Expressions;

namespace QuinielasApi.IRepository.Configuration
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task BulkInsertAsync(List<T> entities);
    }
}
