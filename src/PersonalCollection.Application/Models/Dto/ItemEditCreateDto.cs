using static PersonalCollection.Domain.Constants;

namespace PersonalCollection.Application.Models.Dto
{
    public class ItemEditCreateDto
    {
        public int Id { get; set; }
        public int CollectionId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string?[] CustomStrings { get; set; } = new string?[CustomFieldsCount];
        public string?[] CustomTexts { get; set; } = new string?[CustomFieldsCount];
        public int?[] CustomInts { get; set; } = new int?[CustomFieldsCount];
        public bool[] CustomBools { get; set; } = new bool[CustomFieldsCount];
        public DateTime?[] CustomDates { get; set; } = new DateTime?[CustomFieldsCount];
    }
}
