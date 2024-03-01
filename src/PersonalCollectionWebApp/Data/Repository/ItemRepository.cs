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

        public async Task<IEnumerable<Item>> GetLastAddedItems(int count)
        {
            return await GetAll()
                .Include(i => i.Collection)
                .OrderByDescending(i => i.CreatedDate)
                .Take(count)
                .ToListAsync();
        }
    }
}
