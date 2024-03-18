namespace PersonalCollection.Domain.Entities
{
    public class Collection
    {
        public int Id { get; set; }
        public string UserId { get; set; } // Required foreign key property
        public ApplicationUser User { get; set; } = null!; // Required reference navigation to principal
        public int? ThemeId { get; set; }
        public Theme? Theme { get; set; }
        public ICollection<Item> Items { get; } = []; // Collection navigation containing dependents
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public CustomFieldsSettings? CustomFieldsSettings { get; set; }
    }

    public class CustomFieldsSettings
    {
        public List<CustomField> CustomStrings { get; set; } = [];
        public List<CustomField> CustomTexts { get; set; } = [];
        public List<CustomField> CustomInts { get; set; } = [];
        public List<CustomField> CustomBools { get; set; } = [];
        public List<CustomField> CustomDates { get; set; } = [];

    }

    public class CustomField
    {
        public bool Enable { get; set; }
        public string? Name { get; set;}
    }
}
