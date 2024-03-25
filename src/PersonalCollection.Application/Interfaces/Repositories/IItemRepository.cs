using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.Interfaces.Repositories
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        public Task<Item?> GetItemWithTags(int itemId);
        public IQueryable<Item> SearchItems(string search);
    }
}
