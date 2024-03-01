using Microsoft.EntityFrameworkCore;
using PersonalCollectionWebApp.Data.Repository.Interfaces;
using PersonalCollectionWebApp.Models.Entities;

namespace PersonalCollectionWebApp.Services
{
    public class CollectionService
    {
        private readonly ICollectionRepository _collectionRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IThemeRepository _themeRepository;

        public CollectionService(ICollectionRepository collectionRepository, IItemRepository itemRepository, IThemeRepository themeRepository)
        {
            _collectionRepository = collectionRepository;
            _itemRepository = itemRepository;
            _themeRepository = themeRepository;
        }

        public async Task<IEnumerable<PersonalCollection>> GetUserCollections(string userId)
        {
            return await _collectionRepository.GetUserCollections(userId);
        }

        public async Task<PersonalCollection?> GetCollectionWithItems(int collectionId)
        {
            return await _collectionRepository.GetCollectionWithItems(collectionId);
        }

        public async Task<IEnumerable<PersonalCollection>> GetLargestCollections(int count)
        {
            return await _collectionRepository.GetLargestCollections(count);
        }

        public async Task AddCollection(PersonalCollection collection)
        {
            await _collectionRepository.Create(collection);
            await _collectionRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Item>> GetLastAddedItems(int count)
        {
            return await _itemRepository.GetLastAddedItems(count);
        }

        public async Task AddItemToCollection(Item item)
        {
            await _itemRepository.Create(item);
            await _itemRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Theme>> GetCollectionThemes()
        {
            return await _themeRepository.GetAll().AsNoTracking().ToListAsync();
        }
    }
}
