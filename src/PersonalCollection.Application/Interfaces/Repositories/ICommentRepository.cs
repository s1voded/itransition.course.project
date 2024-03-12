using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.Interfaces.Repositories
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        public Task<IEnumerable<Comment>> GetItemComments(int itemId);
    }
}
