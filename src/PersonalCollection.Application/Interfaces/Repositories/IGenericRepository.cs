namespace PersonalCollection.Application.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity?> GetById(int id);
        Task Create(TEntity entity);
        void Update(TEntity entity);
        void Attach(TEntity entity);
        void Attach(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        Task SaveChangesAsync();
    }
}
