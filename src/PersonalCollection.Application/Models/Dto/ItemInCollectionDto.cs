using AutoMapper;
using PersonalCollection.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCollection.Application.Models.Dto
{
    public class ItemInCollectionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string?[] CustomStrings { get; set; } = [];
        public DateTime?[] CustomDates { get; set; } = [];
        public IEnumerable<string> Tags { get; set; } = [];

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Item, ItemInCollectionDto>()
                .ForMember(dest => dest.Tags, act => act.MapFrom(src => src.Tags.Select(t => t.Name)));
            }
        }
    }
}
