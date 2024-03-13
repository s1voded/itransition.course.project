using Microsoft.EntityFrameworkCore;
using PersonalCollection.Application.Interfaces.Repositories;
using PersonalCollection.Domain.Entities;
using PersonalCollection.Persistence.Contexts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PersonalCollection.Persistence.Repositories
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
                .Include(i => i.Tags)
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

        public async Task<IEnumerable<Item>> SearchItems(string search)
        {
            return await GetAll()
                .Where(e => EF.Functions.Contains(e.Name, search))
                .ToListAsync();
        }
    }
}
