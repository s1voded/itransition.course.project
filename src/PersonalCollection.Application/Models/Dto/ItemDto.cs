using AutoMapper;
using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.Models.Dto
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CollectionName { get; set; }
        public string Author { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Item, ItemDto>()
                .ForMember(dest => dest.CollectionName, act => act.MapFrom(src => src.Collection.Name))
                .ForMember(dest => dest.Author, act => act.MapFrom(src => src.Collection.User.UserName));
            }
        }
    }
}
