using System.ComponentModel.DataAnnotations;
using static PersonalCollection.Domain.Constants;

namespace PersonalCollection.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        [Required, StringLength(DbFieldShortStringLenght)]
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public int CollectionId { get; set; } // Required foreign key property
        public Collection Collection { get; set; } = null!; // Required reference navigation to principal
        public ICollection<Tag>? Tags { get; set; } = [];
        public ICollection<Comment>? Comments { get; set; } = [];

        public string?[] CustomStrings { get; set; } = new string?[CustomFieldsCount];
        public string?[] CustomTexts { get; set; } = new string?[CustomFieldsCount];
        public int?[] CustomInts { get; set; } = new int?[CustomFieldsCount];
        public bool[] CustomBools { get; set; } = new bool[CustomFieldsCount];
        public DateTime?[] CustomDates { get; set; } = new DateTime?[CustomFieldsCount];
    }
}
