namespace PersonalCollection.Domain.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Item> Items { get; } = [];
    }
}
