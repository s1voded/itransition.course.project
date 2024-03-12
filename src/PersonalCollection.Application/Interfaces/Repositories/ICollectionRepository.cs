using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.Interfaces.Repositories
{
    public interface ICollectionRepository : IGenericRepository<Collection>
    {
        public Task<IEnumerable<Collection>> GetLargestCollections(int count);
        public Task<IEnumerable<Collection>> GetUserCollections(string userId);
        public Task<Collection?> GetCollectionWithItems(int collectionId);
    }
}
