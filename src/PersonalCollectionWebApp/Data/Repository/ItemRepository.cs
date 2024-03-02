using Microsoft.EntityFrameworkCore;
using PersonalCollectionWebApp.Data.Repository.Interfaces;
using PersonalCollectionWebApp.Models.Entities;

namespace PersonalCollectionWebApp.Data.Repository
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Item?> GetItemWithCollection(int itemId)
        {
            return await GetAll()
                .Include(i => i.Collection)
                .FirstOrDefaultAsync(i => i.Id == itemId);
        }

        public async Task<IEnumerable<Item>> GetLastAddedItems(int count)
        {
            return await GetAll()
                .Include(i => i.Collection)
                .ThenInclude(c => c.User)
                .OrderByDescending(i => i.CreatedDate)
                .Take(count)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
