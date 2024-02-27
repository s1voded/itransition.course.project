using Microsoft.EntityFrameworkCore;
using PersonalCollectionWebApp.Models;

namespace PersonalCollectionWebApp.Data
{
    public class CollectionRepository : ICollectionRepository
    {
        private ApplicationDbContext _context;

        public CollectionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PersonalCollection> GetCollectionByID(int collectionId)
        {
            return await _context.Collections.FirstOrDefaultAsync(c => c.Id == collectionId);
        }

        public async Task<IEnumerable<PersonalCollection>> GetUserCollections(string userId)
        {
            return await _context.Collections.Where(c => c.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetLastCreatedItemAsync(int itemsCount)
        {
            return await _context.Items.OrderBy(i => i.CreatedDate).Take(itemsCount).ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetLastCreatedItems(int itemsCount)
        {
            throw new NotImplementedException();
        }

        public async Task InsertCollection(PersonalCollection collection)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateCollection(PersonalCollection collection)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteCollection(int collectionID)
        {
            throw new NotImplementedException();
        }
    }

    public interface ICollectionRepository
    {
        Task<IEnumerable<PersonalCollection>> GetUserCollections(string userId);
        Task<IEnumerable<Item>> GetLastCreatedItemAsync(int itemsCount);
        Task<IEnumerable<Item>> GetLastCreatedItems(int itemsCount);
        Task<PersonalCollection> GetCollectionByID(int collectionId);
        Task InsertCollection(PersonalCollection collection);
        Task DeleteCollection(int collectionID);
        Task UpdateCollection(PersonalCollection collection);
    }
}
