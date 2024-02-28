using PersonalCollectionWebApp.Models;

namespace PersonalCollectionWebApp.Data.Repository.Interfaces
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        public Task<IEnumerable<Item>> GetLastAddedItems(int count);
    }
}
