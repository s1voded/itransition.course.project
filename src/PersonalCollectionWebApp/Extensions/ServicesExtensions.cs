﻿using PersonalCollectionWebApp.Data.Repository;
using PersonalCollectionWebApp.Data.Repository.Interfaces;
using PersonalCollectionWebApp.Services;

namespace PersonalCollectionWebApp.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICollectionRepository, CollectionRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IThemeRepository, ThemeRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ILikeRepository, LikeRepository>();
        }

        public static void AddMyServices(this IServiceCollection services)
        {
            services.AddScoped<CollectionService>();
        }
    }
}
