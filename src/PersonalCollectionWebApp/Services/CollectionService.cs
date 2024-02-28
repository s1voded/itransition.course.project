using PersonalCollectionWebApp.Data.Repository.Interfaces;
using PersonalCollectionWebApp.Models;

namespace PersonalCollectionWebApp.Services
{
    public class CollectionService
    {
        private readonly ICollectionRepository _collectionRepository;
        private readonly IItemRepository _itemRepository;

        public CollectionService(ICollectionRepository collectionRepository, IItemRepository itemRepository)
        {
            _collectionRepository = collectionRepository;
            _itemRepository = itemRepository;
        }

        public async Task<IEnumerable<PersonalCollection>> GetUserCollections(string userId)
        {
            return await _collectionRepository.GetUserCollections(userId);
        }

        public async Task<IEnumerable<PersonalCollection>> GetLargestCollections(int count)
        {
            return await _collectionRepository.GetLargestCollections(count);
        }

        public async Task<IEnumerable<Item>> GetLastAddedItems(int count)
        {
            return await _itemRepository.GetLastAddedItems(count);
        }

        public async Task AddCollection(PersonalCollection collection)
        {
            await _collectionRepository.Create(collection);
            await _collectionRepository.SaveChangesAsync();
        }
    }
}
