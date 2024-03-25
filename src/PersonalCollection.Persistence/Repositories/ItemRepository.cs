using Microsoft.EntityFrameworkCore;
using PersonalCollection.Application.Interfaces.Repositories;
using PersonalCollection.Application.Models.Dto;
using PersonalCollection.Domain.Entities;
using PersonalCollection.Persistence.Contexts;

namespace PersonalCollection.Persistence.Repositories
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Item?> GetItemWithTags(int itemId)
        {
            return await GetAll()
                .Include(i => i.Tags)
                .FirstOrDefaultAsync(i => i.Id == itemId);
        }

        public IQueryable<Item> SearchItems(string search)
        {
            var searchCondition = $"\"{search}\"";

            return GetAll()
                .Where(i =>
                EF.Functions.Contains(i.Name, searchCondition) ||
                EF.Functions.Contains(i.CustomStrings, searchCondition) ||
                EF.Functions.Contains(i.CustomTexts, searchCondition) ||
                EF.Functions.Contains(i.CustomInts, searchCondition) ||
                EF.Functions.Contains(i.CustomDates, searchCondition) ||
                EF.Functions.Contains(i.Collection.Name, searchCondition) ||
                EF.Functions.Contains(i.Collection.Description, searchCondition) ||
                EF.Functions.Contains(i.Collection.Theme.Name, searchCondition) ||
                EF.Functions.Contains(i.Collection.User.UserName, searchCondition) ||
                i.Tags.Any(t => EF.Functions.Contains(t.Name, searchCondition)) ||
                i.Comments.Any(c => EF.Functions.Contains(c.Content, searchCondition)));
        }
    }
}
