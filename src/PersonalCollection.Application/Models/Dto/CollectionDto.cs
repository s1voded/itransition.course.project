using AutoMapper;
using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.Models.Dto
{
    public class CollectionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public string? Theme { get; set; }
        public string Author { get; set; }
        public int ItemsCount { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Collection, CollectionDto>()
                .ForMember(dest => dest.Theme, act => act.MapFrom(src => src.Theme.Name))
                .ForMember(dest => dest.Author, act => act.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.ItemsCount, act => act.MapFrom(src => src.Items.Count));
            }
        }
    }
}
