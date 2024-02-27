namespace PersonalCollectionWebApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CollectionId { get; set; } // Required foreign key property
        public PersonalCollection Collection { get; set; } = null!; // Required reference navigation to principal
        public ICollection<Tag>? Tags { get; } = [];
    }
}
