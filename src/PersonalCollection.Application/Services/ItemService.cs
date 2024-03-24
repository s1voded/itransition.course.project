using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PersonalCollection.Application.Interfaces.Repositories;
using PersonalCollection.Application.Models.Dto;
using PersonalCollection.Domain.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace PersonalCollection.Application.Services
{
    public class ItemService
    {
        private readonly IMapper _mapper;
        private readonly IItemRepository _itemRepository;
        private readonly ITagRepository _tagRepository;

        public ItemService(IMapper mapper, IItemRepository itemRepository, ITagRepository tagRepository)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
            _tagRepository = tagRepository;        
        }

        public async Task<ItemEditCreateDto?> GetItemWithCollection(int itemId)
        {
            return await _itemRepository.GetAll()
                .ProjectTo<ItemEditCreateDto>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Id == itemId);
        }
        public async Task<IEnumerable<TagDto>> GetAllItemTags()
        {
            return await _tagRepository.GetAll()
                .ProjectTo<TagDto>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<int> AddItem(ItemEditCreateDto itemDto, IList<TagDto> tagsDto)
        {
            var item = _mapper.Map<Item>(itemDto);

            await _itemRepository.Create(item);
            await _itemRepository.SaveChangesAsync();

            return item.Id;
        }

        public async Task UpdateItem(ItemEditCreateDto itemDto, IList<TagDto> tagsDto)
        {
            var item = await _itemRepository.GetById(itemDto.Id);
            _mapper.Map(itemDto, item);

            _itemRepository.Update(item);
            await _itemRepository.SaveChangesAsync();
        }

        public async Task DeleteItem(int itemId)
        {
            await _itemRepository.GetAll()
                .Where(i => i.Id == itemId)
                .ExecuteDeleteAsync();
        }

        public async Task<IEnumerable<TagWithUsedCountDto>> GetTagsWithUsedCount()
        {
            return await _tagRepository.GetAll()
                .Where(t => t.Items.Count() > 0)
                .ProjectTo<TagWithUsedCountDto>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IList<TagDto>> GetItemTags(int itemId)
        {
            return await _tagRepository.GetAll()
                .Where(t => t.Items.Any(i => i.Id == itemId))
                .ProjectTo<TagDto>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
        }


        public async Task<IEnumerable<ItemDto>> SearchItemsByTag(string tagName)
        {
            return await _itemRepository.GetAll()
                .Where(i => i.Tags.Any(t => t.Name == tagName))
                .ProjectTo<ItemDto>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<ItemDto>> SearchItems(string searchString)
        {
            return await _itemRepository.SearchItems(searchString)
                .ProjectTo<ItemDto>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<TagDto>> SearchTag(string searchString)
        {
            return await _tagRepository.GetAll()
                .Where(t => t.Name.Contains(searchString.ToLower()))
                .ProjectTo<TagDto>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TagDto> AddNewTag(TagDto tagDto)
        {
            var tag = _mapper.Map<Tag>(tagDto);

            await _tagRepository.Create(tag);
            await _tagRepository.SaveChangesAsync();

            return _mapper.Map<TagDto>(tag);
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
