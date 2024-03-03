using System.ComponentModel.DataAnnotations;

namespace PersonalCollectionWebApp.Models.Entities
{
    public class Item
    {
        public int Id { get; set; }
        [Required, StringLength(Constants.DbFieldShortStringLenght)]
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public int CollectionId { get; set; } // Required foreign key property
        public PersonalCollection Collection { get; set; } = null!; // Required reference navigation to principal
        public ICollection<Tag>? Tags { get; set; } = [];

        public string?[] CustomStrings { get; set; } = new string?[3];
        public string?[] CustomTexts { get; set; } = new string?[3];
        public int?[] CustomInts { get; set; } = new int?[3];
        public bool[] CustomBools { get; set; } = new bool[3];
        public DateTime?[] CustomDates { get; set; } = new DateTime?[3];
    }
}
