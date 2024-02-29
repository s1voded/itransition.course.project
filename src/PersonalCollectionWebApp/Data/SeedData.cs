using Microsoft.AspNetCore.Identity;

namespace PersonalCollectionWebApp.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            using var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var user = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                Email = "seed3@example.com",
                UserName = "seed3@example.com",
                EmailConfirmed = true,
            };

            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                await userManager.CreateAsync(user, "password");
            }
        }
    }
}
