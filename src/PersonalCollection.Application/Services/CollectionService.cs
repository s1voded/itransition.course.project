using Microsoft.EntityFrameworkCore;
using PersonalCollection.Application.Interfaces.Repositories;
using PersonalCollection.Application.Models;
using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.Services
{
    public class CollectionService
    {
        private readonly ICollectionRepository _collectionRepository;
        private readonly IThemeRepository _themeRepository;

        public CollectionService(ICollectionRepository collectionRepository, IThemeRepository themeRepository)
        {
            _collectionRepository = collectionRepository;
            _themeRepository = themeRepository;
        }

        public async Task<Collection?> GetCollectionById(int collectionId) => await _collectionRepository.GetById(collectionId);
        public async Task<IEnumerable<Collection>> GetUserCollections(string userId) => await _collectionRepository.GetUserCollections(userId);
        public async Task<Collection?> GetCollectionWithItems(int collectionId) => await _collectionRepository.GetCollectionWithItems(collectionId);
        public async Task<IEnumerable<Collection>> GetLargestCollections(int count) => await _collectionRepository.GetLargestCollections(count);
        public async Task<IEnumerable<Theme>> GetThemes() => await _themeRepository.GetAll().AsNoTracking().ToListAsync();

        public async Task AddCollection(Collection collection)
        {
            await _collectionRepository.Create(collection);
            await _collectionRepository.SaveChangesAsync();
        }

        public async Task UpdateCollection(Collection collection)
        {
            _collectionRepository.Update(collection);
            await _collectionRepository.SaveChangesAsync();
        }

        public async Task DeleteCollection(Collection collection)
        {
            _collectionRepository.Delete(collection);
            await _collectionRepository.SaveChangesAsync();
        }
    }
}
