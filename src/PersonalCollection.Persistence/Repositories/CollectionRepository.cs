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
    }
}
