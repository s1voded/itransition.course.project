using PersonalCollectionWebApp.Data.Repository;
using PersonalCollectionWebApp.Data.Repository.Interfaces;
using PersonalCollectionWebApp.Models.Entities;

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
    }
}
