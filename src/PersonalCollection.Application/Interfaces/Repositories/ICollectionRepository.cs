using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.Interfaces.Repositories
{
    public interface ICollectionRepository : IGenericRepository<Collection>
    {
        public Task<Collection?> GetCollectionWithItems(int collectionId);
    }
}
