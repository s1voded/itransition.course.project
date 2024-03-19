using Azure.Identity;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PersonalCollection.Application.Models.Config;
using PersonalCollection.Application.Services;
using System.Reflection;

namespace PersonalCollection.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AzureBlobConfig>(configuration.GetSection(nameof(AzureBlobConfig)));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMyServices();
            services.AddSingleton(sp =>
            {
                var serviceUri = sp.GetService<IOptions<AzureBlobConfig>>().Value.ServiceUri;
                return new BlobServiceClient(new Uri(serviceUri), new DefaultAzureCredential());
            });
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
