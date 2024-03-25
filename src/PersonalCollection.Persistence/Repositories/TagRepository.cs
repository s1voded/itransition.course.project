using Microsoft.EntityFrameworkCore;
using PersonalCollection.Application.Interfaces.Repositories;
using PersonalCollection.Domain.Entities;
using PersonalCollection.Persistence.Contexts;

namespace PersonalCollection.Persistence.Repositories
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Tag>> GetTagsByIds(int[] tagIds)
        {
            return await GetAll()
                .Where(t => tagIds.Contains(t.Id))
                .ToListAsync();
        }
    }
}
