using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PersonalCollection.Application.Interfaces.Repositories;
using PersonalCollection.Application.Models.Dto;
using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.Services
{
    public class ItemService
    {
        private readonly IMapper _mapper;
        private readonly IItemRepository _itemRepository;
        private readonly ITagRepository _tagRepository;

        public ItemService(IMapper mapper, IItemRepository itemRepository, ITagRepository tagRepository)
        {
            _itemRepository = itemRepository;
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<Item?> GetItemWithCollection(int itemId) => await _itemRepository.GetItemWithCollection(itemId);
        public async Task<IEnumerable<Item>> SearchItems(string searchString) => await _itemRepository.SearchItems(searchString);
        public async Task<IEnumerable<Item>> SearchItemsByTag(string tagName) => await _itemRepository.SearchItemsByTag(tagName);
        public async Task<IEnumerable<Tag>> GetAllItemTags() => await _tagRepository.GetAll().ToListAsync();

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

        public async Task<IEnumerable<TagDto>> GetTagsWithUsedCount()
        {
            return await _tagRepository.GetAll()
                .Where(t => t.Items.Count() > 0)
                .ProjectTo<TagDto>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<ItemDto>> GetLastAddedItems(int count)
        {
            return await _itemRepository.GetAll()
                .OrderByDescending(i => i.CreatedDate)
                .Take(count)
                .ProjectTo<ItemDto>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
