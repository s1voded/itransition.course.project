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

        public string?[] CustomStrings { get; set; } = new string?[Constants.CustomFieldsCount];
        public string?[] CustomTexts { get; set; } = new string?[Constants.CustomFieldsCount];
        public int?[] CustomInts { get; set; } = new int?[Constants.CustomFieldsCount];
        public bool[] CustomBools { get; set; } = new bool[Constants.CustomFieldsCount];
        public DateTime?[] CustomDates { get; set; } = new DateTime?[Constants.CustomFieldsCount];
    }
}
