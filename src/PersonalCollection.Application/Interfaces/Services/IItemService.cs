using PersonalCollection.Application.Models.Dto;

namespace PersonalCollection.Application.Interfaces.Services
{
    public interface IItemService
    {
        public Task<int> AddItem(ItemEditCreateDto itemDto, IList<TagDto> tagsDto);
        public Task<ItemEditCreateDto?> GetItemById(int itemId);
        public Task<ItemDetailDto?> GetItemDetailById(int itemId);
        public Task<IEnumerable<ItemDto>> GetLastAddedItems(int count);
        public Task<IEnumerable<ItemDto>> SearchItemsByTag(string tagName);
        public Task<IEnumerable<ItemDto>> SearchItems(string searchString);
        public Task UpdateItem(ItemEditCreateDto itemDto, IList<TagDto> tagsDto);
        public Task DeleteItem(int itemId);

        public Task<TagDto> AddNewTag(TagDto tagDto);
        public Task<IEnumerable<TagDto>> GetAllItemTags();
        public Task<IList<TagDto>> GetItemTags(int itemId);
        public Task<IEnumerable<TagWithUsedCountDto>> GetTagsWithUsedCount();
        public Task<IEnumerable<TagDto>> SearchTag(string searchString);
    }
}
