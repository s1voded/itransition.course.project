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
        public ICollection<Tag>? Tags { get; } = [];
        [StringLength(Constants.DbFieldShortStringLenght)]
        public string? CustomString1 { get; set; }
        [StringLength(Constants.DbFieldShortStringLenght)]
        public string? CustomString2 { get; set; }
        [StringLength(Constants.DbFieldShortStringLenght)]
        public string? CustomString3 { get; set; }
        public int? CustomInt1 { get; set; }
        public int? CustomInt2 { get; set; }
        public int? CustomInt3 { get; set; }
        [StringLength(Constants.DbFieldLongStringLenght)]
        public string? CustomMultiLineText1 { get; set; }
        [StringLength(Constants.DbFieldLongStringLenght)]
        public string? CustomMultiLineText2 { get; set; }
        [StringLength(Constants.DbFieldLongStringLenght)]
        public string? CustomMultiLineText3 { get; set; }
        public bool? CustomBool1 { get; set; }
        public bool? CustomBool2 { get; set;}
        public bool? CustomBool3 { get; set;}
        public DateTime? CustomDateTime1 { get; set; }
        public DateTime? CustomDateTime2 { get; set; }
        public DateTime? CustomDateTime3 { get; set;}
    }
}
