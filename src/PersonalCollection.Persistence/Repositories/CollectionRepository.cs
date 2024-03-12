using Microsoft.EntityFrameworkCore;
using PersonalCollection.Application.Interfaces.Repositories;
using PersonalCollection.Domain.Entities;
using PersonalCollection.Persistence.Contexts;

namespace PersonalCollection.Persistence.Repositories
{
    public class CollectionRepository : GenericRepository<Collection>, ICollectionRepository
    {
        public CollectionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Collection>> GetLargestCollections(int count)
        {
            return await GetAll()
                .Include(c => c.Theme)
                .Include(c => c.User)
                .Include(c => c.Items)
                .OrderByDescending(c => c.Items.Count)
                .Take(count)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Collection>> GetUserCollections(string userId)
        {
            return await GetAll()
                .Include(c => c.Theme)
                .Where(c => c.UserId == userId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Collection?> GetCollectionWithItems(int collectionId)
        {
            return await GetAll()
                .Include(c => c.Theme)
                .Include(c => c.User)
                .Include(c => c.Items).ThenInclude(i => i.Tags)
                .FirstOrDefaultAsync(c => c.Id == collectionId);
        }
    }
}
