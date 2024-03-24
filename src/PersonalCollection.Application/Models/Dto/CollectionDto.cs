namespace PersonalCollection.Application.Models.Dto
{
    public class CollectionDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public string? Theme { get; set; }
        public string Author { get; set; }
        public int ItemsCount { get; set; }
    }
}
