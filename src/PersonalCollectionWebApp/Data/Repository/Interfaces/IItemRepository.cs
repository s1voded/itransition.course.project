using PersonalCollectionWebApp.Models.Entities;

namespace PersonalCollectionWebApp.Data.Repository.Interfaces
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        public Task<IEnumerable<Item>> GetLastAddedItems(int count);
        public Task<IEnumerable<Item>> GetCollectionItemsWithTags(int collectionId);
    }
}
