using Microsoft.AspNetCore.Authorization;
using PersonalCollectionWebApp.Policies.Handlers;

namespace PersonalCollectionWebApp.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddHandlersServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorizationHandler, IsCollectionOwnerHandler>();
            services.AddScoped<IAuthorizationHandler, IsAdminHandler>();
            services.AddScoped<IAuthorizationHandler, UserNotBlockedHandler>();
        }
    }
}
