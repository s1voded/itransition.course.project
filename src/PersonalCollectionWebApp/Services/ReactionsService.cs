using PersonalCollection.Application.Interfaces.Repositories;
using PersonalCollection.Domain.Entities;

namespace PersonalCollectionWebApp.Services
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

        public async Task AddComment(Comment comment)
        {
            await _commentRepository.Create(comment);
            await _commentRepository.SaveChangesAsync();
        }
    }
}
