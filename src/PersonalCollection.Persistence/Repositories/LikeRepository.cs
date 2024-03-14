using Microsoft.EntityFrameworkCore;
using PersonalCollection.Application.Interfaces.Repositories;
using PersonalCollection.Domain.Entities;
using PersonalCollection.Persistence.Contexts;

namespace PersonalCollection.Persistence.Repositories
{
    public class LikeRepository : GenericRepository<Like>, ILikeRepository
    {
        public LikeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Like>> GetItemLikes(int itemId)
        {
            return await GetAll()
                .Include(l => l.User)
                .Where(l => l.ItemId == itemId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Like?> GetLikeForItemByUser(int itemId, string userId)
        {
            return await GetAll()
                .Where(l => l.ItemId == itemId)
                .FirstOrDefaultAsync(l => l.UserId == userId);
        }
    }
}
