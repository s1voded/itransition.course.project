using PersonalCollectionWebApp.Models.Entities;

namespace PersonalCollectionWebApp.Data.Repository.Interfaces
{
    public interface ICollectionRepository : IGenericRepository<PersonalCollection>
    {
        public Task<IEnumerable<PersonalCollection>> GetLargestCollections(int count);
        public Task<IEnumerable<PersonalCollection>> GetUserCollections(string userId);
        public Task<PersonalCollection> GetCollectionWithItems(int collectionId);
    }
}
