using PersonalCollection.Application.Models.Dto;
using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.Interfaces.Services
{
    public interface ICollectionService
    {
        public Task<int> AddCollection(CollectionEditCreateDto collectionDto);
        public Task<CollectionEditCreateDto?> GetCollectionById(int collectionId);
        public Task<CollectionWithItemsDto?> GetCollectionWithItems(int collectionId);
        public Task<CollectionCustomFieldSettingsDto?> GetCollectionCustomFieldSettings(int collectionId);
        public Task<IEnumerable<CollectionDto>> GetLargestCollections(int count);
        public Task<IEnumerable<CollectionDto>> GetUserCollections(string userId);
        public Task UpdateCollection(CollectionEditCreateDto collectionDto);
        public Task UpdateCollectionImage(int collectionId, string? image);
        public Task DeleteCollection(int collectionId);
        public Task<IEnumerable<Theme>> GetThemes();
    }
}
