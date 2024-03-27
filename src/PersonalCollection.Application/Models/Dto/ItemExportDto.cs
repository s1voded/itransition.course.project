using static PersonalCollection.Domain.Constants;

namespace PersonalCollection.Application.Models.Dto
{
    public class ItemExportDto
    {
        public string CollectionName { get; set; }
        public string? CollectionTheme { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Tags { get; set; }
        public string CustomStrings { get; set; }
        public string CustomTexts { get; set; }
        public string CustomInts { get; set; }
        public string CustomBools { get; set; }
        public string CustomDates { get; set; }
    }
}
