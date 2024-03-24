using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.Models.Dto
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? Author { get; set; }
        public int ItemId { get; set; }
        public string Content { get; set; }
        public DateTime AddedDateTime { get; set; }
    }
}
