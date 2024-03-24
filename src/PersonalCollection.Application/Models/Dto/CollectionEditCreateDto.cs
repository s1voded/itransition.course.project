using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.Models.Dto
{
    public class CollectionEditCreateDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ThemeId { get; set; }
        public CustomFieldsSettings? CustomFieldsSettings { get; set; }
    }
}
