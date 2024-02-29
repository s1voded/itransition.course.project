using Microsoft.EntityFrameworkCore;
using PersonalCollectionWebApp.Data.Repository.Interfaces;
using PersonalCollectionWebApp.Models.Entities;

namespace PersonalCollectionWebApp.Data.Repository
{
    public class CollectionRepository : GenericRepository<PersonalCollection>, ICollectionRepository
    {
        public CollectionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PersonalCollection>> GetLargestCollections(int count)
        {
            return await GetAll()
                .Include(c => c.Theme)
                .Include(c => c.User)
                .Include(c => c.Items)
                .OrderByDescending(c => c.Items.Count)
                .Take(count)
                .ToListAsync();
        }

        public async Task<IEnumerable<PersonalCollection>> GetUserCollections(string userId)
        {
            return await GetAll()
                .Include(c => c.Theme)
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }
    }
}
