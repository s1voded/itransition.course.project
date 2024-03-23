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
