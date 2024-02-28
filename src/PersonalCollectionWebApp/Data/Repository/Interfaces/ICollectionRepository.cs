using PersonalCollectionWebApp.Models;

namespace PersonalCollectionWebApp.Data.Repository.Interfaces
{
    public interface ICollectionRepository : IGenericRepository<PersonalCollection>
    {
        public Task<IEnumerable<PersonalCollection>> GetLargestCollections(int count);
        public Task<IEnumerable<PersonalCollection>> GetUserCollections(string userId);
    }
}
