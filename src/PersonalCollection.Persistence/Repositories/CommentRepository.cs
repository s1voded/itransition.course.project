using Microsoft.EntityFrameworkCore;
using PersonalCollection.Application.Interfaces.Repositories;
using PersonalCollection.Domain.Entities;
using PersonalCollection.Persistence.Contexts;

namespace PersonalCollection.Persistence.Repositories
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
