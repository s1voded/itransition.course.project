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
    }
}
