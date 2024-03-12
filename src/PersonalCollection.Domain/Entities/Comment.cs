namespace PersonalCollection.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public string Content { get; set; }
        public DateTime AddedDateTime { get; set; }
    }
}
