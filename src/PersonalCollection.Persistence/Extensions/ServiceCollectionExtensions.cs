using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalCollection.Application.Interfaces.Repositories;
using PersonalCollection.Persistence.Contexts;
using PersonalCollection.Persistence.Repositories;

namespace PersonalCollection.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddRepositories();
        }

        private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString, 
                builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICollectionRepository, CollectionRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IThemeRepository, ThemeRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ILikeRepository, LikeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
