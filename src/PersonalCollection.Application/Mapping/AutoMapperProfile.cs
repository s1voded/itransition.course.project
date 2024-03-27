using AutoMapper;
using PersonalCollection.Application.Models.Dto;
using PersonalCollection.Domain.Entities;
using System.Security.Claims;
using static PersonalCollection.Domain.Constants;

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
            CreateMap<Item, ItemDetailDto>();
            CreateMap<Item, ItemEditCreateDto>();
            CreateMap<Item, ItemDto>()
                .ForMember(dest => dest.CollectionName, act => act.MapFrom(src => src.Collection.Name))
                .ForMember(dest => dest.Author, act => act.MapFrom(src => src.Collection.User.UserName))
                .ForMember(dest => dest.Tags, act => act.MapFrom(src => src.Tags.Select(t => t.Name)));
            CreateMap<Item, ItemInCollectionDto>()
                .ForMember(dest => dest.Tags, act => act.MapFrom(src => src.Tags.Select(t => t.Name)));
            CreateMap<Item, ItemExportDto>()
                .ForMember(dest => dest.CollectionName, act => act.MapFrom(src => src.Collection.Name))
                .ForMember(dest => dest.CollectionTheme, act => act.MapFrom(src => src.Collection.Theme.Name))
                .ForMember(dest => dest.Tags, act => act.MapFrom(src => string.Join(CsvItemSeparator, src.Tags.Select(t => t.Name))))
                .ForMember(dest => dest.CustomStrings, act => act.MapFrom(src => string.Join(CsvItemSeparator, src.CustomStrings)))
                .ForMember(dest => dest.CustomTexts, act => act.MapFrom(src => string.Join(CsvItemSeparator, src.CustomTexts)))
                .ForMember(dest => dest.CustomInts, act => act.MapFrom(src => string.Join(CsvItemSeparator, src.CustomInts)))
                .ForMember(dest => dest.CustomBools, act => act.MapFrom(src => string.Join(CsvItemSeparator, src.CustomBools)))
                .ForMember(dest => dest.CustomDates, act => act.MapFrom(src => string.Join(CsvItemSeparator, src.CustomDates)));

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
