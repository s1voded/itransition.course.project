﻿using AutoMapper;
using PersonalCollectionWebApp.Data;
using System.Security.Claims;

namespace PersonalCollectionWebApp.Models.Dto
{
    public class ApplicationUserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public bool IsBlocked { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<ApplicationUser, ApplicationUserDto>()
                .ForMember(dest => dest.Roles, act => act.MapFrom(src => src.Claims.Where(c => c.ClaimType == ClaimTypes.Role).Select(c => c.ClaimValue)));
            }
        }
    }
}