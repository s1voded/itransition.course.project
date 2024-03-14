using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.Interfaces.Repositories
{
    public interface ILikeRepository : IGenericRepository<Like>
    {
        public Task<IEnumerable<Like>> GetItemLikes(int itemId);
        public Task<Like?> GetLikeForItemByUser(int itemId, string userId);
    }
}
