using Microsoft.EntityFrameworkCore;
using PersonalCollectionWebApp.Data;
using PersonalCollectionWebApp.Data.Repository.Interfaces;
using PersonalCollectionWebApp.Models;

namespace PersonalCollectionWebApp.Services
{
    public class CollectionService
    {
        private readonly ICollectionRepository _repository;

        public CollectionService(ICollectionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PersonalCollection>> GetUserCollections(string userId)
        {
            return await _repository.GetByCondition(c => c.UserId == userId).ToListAsync();
        }

        public async Task AddCollection(PersonalCollection collection)
        {
            await _repository.Create(collection);
            await _repository.SaveChangesAsync();
        }
    }
}
