using AutoMapper;
using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.Models.Dto
{
    public class TagDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Tag, TagDto>()
                .ForMember(dest => dest.Count, act => act.MapFrom(src => src.Items.Count));
            }
        }
    }
}
