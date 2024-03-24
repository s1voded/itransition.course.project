using AutoMapper;
using PersonalCollection.Application.Models.Dto;
using PersonalCollection.Domain.Entities;
using System.Security.Claims;

namespace PersonalCollection.Application.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>()
                .ForMember(dest => dest.Roles, act => act.MapFrom(src => src.Claims.Where(c => c.ClaimType == ClaimTypes.Role).Select(c => c.ClaimValue)));

            CreateMap<CollectionEditCreateDto, Collection>();
            CreateMap<Collection, CollectionEditCreateDto>();
            CreateMap<Collection, CollectionCustomFieldSettingsDto>();
            CreateMap<Collection, CollectionWithItemsDto>()
                .ForMember(dest => dest.Theme, act => act.MapFrom(src => src.Theme.Name))
                .ForMember(dest => dest.Author, act => act.MapFrom(src => src.User.UserName));
            CreateMap<Collection, CollectionDto>()
                .ForMember(dest => dest.Theme, act => act.MapFrom(src => src.Theme.Name))
                .ForMember(dest => dest.Author, act => act.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.ItemsCount, act => act.MapFrom(src => src.Items.Count));

            CreateMap<ItemEditCreateDto, Item>();
            CreateMap<Item, ItemEditCreateDto>();
            CreateMap<Item, ItemDto>()
                .ForMember(dest => dest.CollectionName, act => act.MapFrom(src => src.Collection.Name))
                .ForMember(dest => dest.Author, act => act.MapFrom(src => src.Collection.User.UserName))
                .ForMember(dest => dest.Tags, act => act.MapFrom(src => src.Tags.Select(t => t.Name)));
            CreateMap<Item, ItemInCollectionDto>()
                .ForMember(dest => dest.Tags, act => act.MapFrom(src => src.Tags.Select(t => t.Name)));

            CreateMap<Tag, TagDto>();
            CreateMap<TagDto, Tag>();
            CreateMap<Tag, TagWithUsedCountDto>()
                .ForMember(dest => dest.Count, act => act.MapFrom(src => src.Items.Count));

            CreateMap<Comment, CommentDto>()
                .ForMember(dest => dest.Author, act => act.MapFrom(src => src.User.UserName));
            CreateMap<CommentDto, Comment>();

            CreateMap<Like, LikeDto>()
                .ForMember(dest => dest.Author, act => act.MapFrom(src => src.User.UserName));
            CreateMap<LikeDto, Like>();
        }
    }
}
