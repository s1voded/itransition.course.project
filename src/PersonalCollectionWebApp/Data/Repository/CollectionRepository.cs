using Microsoft.EntityFrameworkCore;
using PersonalCollectionWebApp.Data.Repository.Interfaces;
using PersonalCollectionWebApp.Models;

namespace PersonalCollectionWebApp.Data.Repository
{
    public class CollectionRepository : GenericRepository<PersonalCollection>, ICollectionRepository
    {
        public CollectionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
