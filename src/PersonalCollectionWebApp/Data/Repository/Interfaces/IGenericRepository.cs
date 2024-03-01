
namespace PersonalCollectionWebApp.Data.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity?> GetById(int id);
        Task Create(TEntity entity);
        void Update(int id, TEntity entity);
        void Delete(TEntity entity);
        Task SaveChangesAsync();
    }
}
