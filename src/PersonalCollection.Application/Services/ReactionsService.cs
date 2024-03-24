using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PersonalCollection.Application.Interfaces.Repositories;
using PersonalCollection.Application.Models.Dto;
using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.Services
{
    public class ReactionsService
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;
        private readonly ILikeRepository _likeRepository;

        public ReactionsService(IMapper mapper, ICommentRepository commentRepository, ILikeRepository likeRepository)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
            _likeRepository = likeRepository;
        }

        public async Task<IEnumerable<CommentDto>> GetItemComments(int itemId)
        {
            return await _commentRepository.GetAll()
                .Where(c => c.ItemId == itemId)
                .ProjectTo<CommentDto>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<LikeDto>> GetItemLikes(int itemId)
        {
            return await _likeRepository.GetAll()
                .Where(l => l.ItemId == itemId)
                .ProjectTo<LikeDto>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task UpdateUserLike(int itemId, string userId)
        {
            var like = await _likeRepository.GetAll()
                .Where(l => l.ItemId == itemId)
                .AsNoTracking()
                .FirstOrDefaultAsync(l => l.UserId == userId);

            if (like != null) await DeleteLike(like.Id);
            else await AddLike(itemId, userId);
        }

        private async Task DeleteLike(int likeId)
        {
            await _likeRepository.GetAll()
                    .Where(l => l.Id == likeId)
                    .ExecuteDeleteAsync();
        }

        private async Task AddLike(int itemId, string userId)
        {
            var newLike = new Like() { ItemId = itemId, UserId = userId };
            await _likeRepository.Create(newLike);
            await _likeRepository.SaveChangesAsync();
        }

        public async Task AddComment(CommentDto commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);

            await _commentRepository.Create(comment);
            await _commentRepository.SaveChangesAsync();
        }
    }
}
