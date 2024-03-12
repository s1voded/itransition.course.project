using Microsoft.Extensions.DependencyInjection;
using PersonalCollection.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
