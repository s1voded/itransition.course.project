using Microsoft.EntityFrameworkCore;
using PersonalCollectionWebApp.Data.Repository.Interfaces;
using PersonalCollectionWebApp.Models.Entities;

namespace PersonalCollectionWebApp.Data.Repository
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Comment>> GetItemComments(int itemId)
        {
            return await GetAll()
                .Include(c => c.User)
                .Where(c => c.ItemId == itemId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
