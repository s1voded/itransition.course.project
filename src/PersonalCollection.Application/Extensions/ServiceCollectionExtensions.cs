using Microsoft.Extensions.DependencyInjection;
using PersonalCollection.Application.Services;
using System.Reflection;

namespace PersonalCollection.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMyServices();
        }

        private static void AddMyServices(this IServiceCollection services)
        {
            services.AddScoped<CollectionService>();
            services.AddScoped<UserManagerService>();
            services.AddScoped<ReactionsService>();
            services.AddScoped<ImageStorageService>();
        }
    }
}
