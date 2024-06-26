﻿using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.Models.Dto
{
    public class CollectionWithItemsDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public string? Theme { get; set; }
        public string Author { get; set; }
        public CustomFieldsSettings? CustomFieldsSettings { get; set; }
        public IEnumerable<ItemInCollectionDto> Items { get; set; } = [];
    }
}
