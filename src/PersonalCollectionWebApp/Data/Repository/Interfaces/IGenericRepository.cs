﻿using System.Linq.Expressions;

namespace PersonalCollectionWebApp.Data.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(int id);
        IQueryable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression);
        Task Create(TEntity entity);
        Task Update(int id, TEntity entity);
        Task Delete(TEntity entity);
        Task SaveChangesAsync();
    }
}
