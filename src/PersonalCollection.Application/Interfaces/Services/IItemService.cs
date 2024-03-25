using PersonalCollection.Application.Models.Dto;

namespace PersonalCollection.Application.Interfaces.Services
{
    public interface IItemService
    {
        public Task<int> AddItem(ItemEditCreateDto itemDto, IEnumerable<TagDto> tagsDto);
        public Task<T?> GetItemById<T>(int itemId);
        public Task<IEnumerable<ItemDto>> GetLastAddedItems(int count);
        public Task<IEnumerable<ItemDto>> SearchItemsByTag(string tagName);
        public Task<IEnumerable<ItemDto>> SearchItems(string searchString);
        public Task UpdateItem(ItemEditCreateDto itemDto, IEnumerable<TagDto> tagsDto);
        public Task DeleteItem(int itemId);

        public Task<TagDto> AddNewTag(TagDto tagDto);
        public Task<IEnumerable<TagDto>> GetAllItemTags();
        public Task<IEnumerable<TagDto>> GetItemTags(int itemId);
        public Task<IEnumerable<TagWithUsedCountDto>> GetTagsWithUsedCount();
        public Task<IEnumerable<TagDto>> SearchTag(string searchString);
    }
}
