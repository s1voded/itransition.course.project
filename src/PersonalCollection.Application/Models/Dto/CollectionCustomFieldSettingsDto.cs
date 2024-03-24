using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.Models.Dto
{
    public class CollectionCustomFieldSettingsDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public CustomFieldsSettings? CustomFieldsSettings { get; set; }
    }
}
