using PersonalCollectionWebApp.Data.Repository.Interfaces;
using PersonalCollectionWebApp.Models;

namespace PersonalCollectionWebApp.Data.Repository
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
