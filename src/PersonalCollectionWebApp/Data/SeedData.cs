using Microsoft.AspNetCore.Identity;
using PersonalCollection.Domain.Entities;
using PersonalCollection.Persistence.Contexts;
using System.Security.Claims;

namespace PersonalCollectionWebApp.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            using var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (userManager.Users.Any())
            {
                return;
            }

            var users = new ApplicationUser[]
            {
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "valera@example.com",
                    UserName = "valera@example.com",
                    EmailConfirmed = true,
                },
                new ApplicationUser
                {
                    Id= Guid.NewGuid().ToString(),
                    Email = "paraska@example.com",
                    UserName = "paraska@example.com",
                    EmailConfirmed = true,
                },
                new ApplicationUser
                {
                    Id= Guid.NewGuid().ToString(),
                    Email = "ivan@example.com",
                    UserName = "ivan@example.com",
                    EmailConfirmed = true,
                }
            };

            foreach (var user in users)
            {
                if (!context.Users.Any(u => u.UserName == user.UserName))
                {
                    var result = await userManager.CreateAsync(user, "passWord100500!");
                }
            }

            //await userManager.AddClaimAsync(users.First(), new Claim(ClaimTypes.Role, Constants.AdminRole));

            var booksTheme = new Theme { Id = 1, Name = "Books" };
            var signsTheme = new Theme { Id = 2, Name = "Signs" };
            var stampsTheme = new Theme { Id = 3, Name = "Stamps" };

            var rarityTag = new Tag { Id = 1, Name = "Rarity" };
            var oldTag = new Tag { Id = 2, Name = "Old" };
            var expansive = new Tag { Id = 3, Name = "Expansive" };


        }
    }
}
