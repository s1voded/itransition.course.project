
using Microsoft.EntityFrameworkCore;
using PersonalCollectionWebApp.Data.Repository.Interfaces;
using System.Linq.Expressions;

namespace PersonalCollectionWebApp.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity: class
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetAll() => _context.Set<TEntity>();
        public async Task<TEntity> GetById(int id) => await _context.Set<TEntity>().FindAsync(id);
        public IQueryable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression) => _context.Set<TEntity>().Where(expression);
        public async Task Create(TEntity entity) => await _context.Set<TEntity>().AddAsync(entity);
        public async Task Update(int id, TEntity entity) => _context.Set<TEntity>().Update(entity);
        public async Task Delete(TEntity entity) => _context.Set<TEntity>().Remove(entity);
        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
