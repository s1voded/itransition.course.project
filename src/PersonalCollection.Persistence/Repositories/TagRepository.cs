using Microsoft.EntityFrameworkCore;
using PersonalCollection.Application.Interfaces.Repositories;
using PersonalCollection.Application.Models;
using PersonalCollection.Domain.Entities;
using PersonalCollection.Persistence.Contexts;

namespace PersonalCollection.Persistence.Repositories
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TagDto>> GetTagsWithUsedCount()
        {
            return await GetAll()
                .Where(t => t.Items.Count() > 0)
                .Select(t => new TagDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    Count = t.Items.Count()
                })
                .ToListAsync();
        }
    }
}
