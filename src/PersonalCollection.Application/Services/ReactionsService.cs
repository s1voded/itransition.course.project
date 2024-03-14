using PersonalCollection.Application.Interfaces.Repositories;
using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.Services
{
    public class ReactionsService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly ILikeRepository _likeRepository;

        public ReactionsService(ICommentRepository commentRepository, ILikeRepository likeRepository)
        {
            _commentRepository = commentRepository;
            _likeRepository = likeRepository;
        }

        public async Task<IEnumerable<Comment>> GetItemComments(int itemId)
        {
            return await _commentRepository.GetItemComments(itemId);
        }

        public async Task<IEnumerable<Like>> GetItemLikes(int itemId)
        {
            return await _likeRepository.GetItemLikes(itemId);
        }

        public async Task<Like?> GetLikeForItemByUser(int itemId, string userId)
        {
            return await _likeRepository.GetLikeForItemByUser(itemId, userId);
        }

        public async Task AddLike(Like like)
        {
            await _likeRepository.Create(like);
            await _likeRepository.SaveChangesAsync();
        }

        public async Task DeleteLike(Like like)
        {
            _likeRepository.Delete(like);
            await _likeRepository.SaveChangesAsync();
        }

        public async Task AddComment(Comment comment)
        {
            await _commentRepository.Create(comment);
            await _commentRepository.SaveChangesAsync();
        }
    }
}
