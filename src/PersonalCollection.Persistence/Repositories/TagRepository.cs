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
    }
}
