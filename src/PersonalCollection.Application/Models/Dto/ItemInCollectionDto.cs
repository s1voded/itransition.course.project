﻿namespace PersonalCollection.Application.Models.Dto
{
    public class ItemInCollectionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string?[] CustomStrings { get; set; } = [];
        public DateTime?[] CustomDates { get; set; } = [];
        public IEnumerable<string> Tags { get; set; } = [];
    }
}
