using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.Interfaces.Repositories
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        public Task<Item?> GetItemWithCollection(int itemId);
        public IQueryable<Item> SearchItems(string search);
        public Task<IEnumerable<Item>> SearchItemsByTag(string tagName);
    }
}
