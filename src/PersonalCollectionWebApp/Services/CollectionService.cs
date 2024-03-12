using Microsoft.EntityFrameworkCore;
using PersonalCollection.Application.Interfaces.Repositories;
using PersonalCollection.Domain.Entities;

namespace PersonalCollectionWebApp.Services
{
    public class CollectionService
    {
        private readonly ICollectionRepository _collectionRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IThemeRepository _themeRepository;
        private readonly ITagRepository _tagRepository;

        public CollectionService(ICollectionRepository collectionRepository, 
            IItemRepository itemRepository, 
            IThemeRepository themeRepository, 
            ITagRepository tagRepository)
        {
            _collectionRepository = collectionRepository;
            _itemRepository = itemRepository;
            _themeRepository = themeRepository;
            _tagRepository = tagRepository;
        }

        public async Task<Collection?> GetCollectionById(int collectionId)
        {
            return await _collectionRepository.GetById(collectionId);
        }

        public async Task<IEnumerable<Collection>> GetUserCollections(string userId)
        {
            return await _collectionRepository.GetUserCollections(userId);
        }

        public async Task<Collection?> GetCollectionWithItems(int collectionId)
        {
            return await _collectionRepository.GetCollectionWithItems(collectionId);
        }

        public async Task<IEnumerable<Collection>> GetLargestCollections(int count)
        {
            return await _collectionRepository.GetLargestCollections(count);
        }

        public async Task AddCollection(Collection collection)
        {
            await _collectionRepository.Create(collection);
            await _collectionRepository.SaveChangesAsync();
        }

        public async Task UpdateCollection(Collection collection)
        {
            _collectionRepository.Update(collection.Id, collection);
            await _collectionRepository.SaveChangesAsync();
        }

        public async Task DeleteCollection(Collection collection)
        {
            _collectionRepository.Delete(collection);
            await _collectionRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Item>> GetLastAddedItems(int count)
        {
            return await _itemRepository.GetLastAddedItems(count);
        }

        public async Task AddItem(Item item)
        {
            await _itemRepository.Create(item);
            await _itemRepository.SaveChangesAsync();
        }

        public async Task UpdateItem(Item item)
        {
            _itemRepository.Update(item.Id, item);
            await _itemRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Theme>> GetThemes()
        {
            return await _themeRepository.GetAll().AsNoTracking().ToListAsync();
        }

        public async Task<Item?> GetItemWithCollection(int itemId)
        {
            return await _itemRepository.GetItemWithCollection(itemId);
        }

        public async Task<IEnumerable<Tag>> GetAllItemTags()
        {
            return await _tagRepository.GetAll().ToListAsync();
        }

        public async Task DeleteItem(Item item)
        {
            _itemRepository.Delete(item);
            await _itemRepository.SaveChangesAsync();
        }
    }
}
