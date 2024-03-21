using Microsoft.EntityFrameworkCore;
using PersonalCollection.Application.Interfaces.Repositories;
using PersonalCollection.Application.Models;
using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.Services
{
    public class ItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly ITagRepository _tagRepository;

        public ItemService(IItemRepository itemRepository, ITagRepository tagRepository)
        {
            _itemRepository = itemRepository;
            _tagRepository = tagRepository;
        }

        public async Task<IEnumerable<Item>> GetLastAddedItems(int count) => await _itemRepository.GetLastAddedItems(count);
        public async Task<Item?> GetItemWithCollection(int itemId) => await _itemRepository.GetItemWithCollection(itemId);
        public async Task<IEnumerable<Item>> SearchItems(string searchString) => await _itemRepository.SearchItems(searchString);
        public async Task<IEnumerable<Item>> SearchItemsByTag(string tagName) => await _itemRepository.SearchItemsByTag(tagName);
        public async Task<IEnumerable<Tag>> GetAllItemTags() => await _tagRepository.GetAll().ToListAsync();
        public async Task<IEnumerable<TagDto>> GetTagsWithUsedCount() => await _tagRepository.GetTagsWithUsedCount();

        public async Task AddItem(Item item)
        {
            await _itemRepository.Create(item);
            await _itemRepository.SaveChangesAsync();
        }

        public async Task UpdateItem(Item item)
        {
            _itemRepository.Update(item);
            await _itemRepository.SaveChangesAsync();
        }

        public async Task DeleteItem(Item item)
        {
            _itemRepository.Delete(item);
            await _itemRepository.SaveChangesAsync();
        }
    }
}
