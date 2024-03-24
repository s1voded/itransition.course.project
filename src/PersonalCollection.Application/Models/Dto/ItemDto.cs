namespace PersonalCollection.Application.Models.Dto
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CollectionName { get; set; }
        public string Author { get; set; }
        public IEnumerable<string> Tags { get; set; } = [];
    }
}
