using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.Interfaces.Repositories
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        public Task<IEnumerable<Item>> GetLastAddedItems(int count);
        public Task<Item?> GetItemWithCollection(int itemId);
        public Task<IEnumerable<Item>> SearchItems(string search);
        public Task<IEnumerable<Item>> SearchItemsByTag(string tagName);
    }
}
