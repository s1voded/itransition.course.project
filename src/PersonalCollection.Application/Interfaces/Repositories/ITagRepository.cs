using PersonalCollection.Application.Models;
using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.Interfaces.Repositories
{
    public interface ITagRepository : IGenericRepository<Tag>
    {
        public Task<IEnumerable<TagDto>> GetTagsWithUsedCount();
    }
}
