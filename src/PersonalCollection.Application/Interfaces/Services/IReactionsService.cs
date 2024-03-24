using PersonalCollection.Application.Models.Dto;

namespace PersonalCollection.Application.Interfaces.Services
{
    public interface IReactionsService
    {
        public Task AddComment(CommentDto commentDto);
        public Task<IEnumerable<CommentDto>> GetItemComments(int itemId);

        public Task UpdateUserLike(int itemId, string userId);
        public Task<IEnumerable<LikeDto>> GetItemLikes(int itemId);
    }
}
