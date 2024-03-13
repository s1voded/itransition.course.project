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
                .Include(i => i.Collection)
                .Include(i => i.Tags)
                .Include(i => i.Comments)
                .Where(i => 
                EF.Functions.Contains(i.Name, search) || 
                EF.Functions.Contains(i.CustomStrings, search) ||
                EF.Functions.Contains(i.CustomTexts, search) ||
                EF.Functions.Contains(i.CustomInts, search) ||
                EF.Functions.Contains(i.CustomDates, search) ||
                EF.Functions.Contains(i.Collection.Name, search) ||
                EF.Functions.Contains(i.Collection.Description, search) ||
                i.Tags.Any(t => EF.Functions.Contains(t.Name, search)) ||
                i.Comments.Any(c => EF.Functions.Contains(c.Content, search)))
                .ToListAsync();
        }
    }
}
