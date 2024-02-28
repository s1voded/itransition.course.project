using Microsoft.AspNetCore.Identity;
using PersonalCollectionWebApp.Models;

namespace PersonalCollectionWebApp.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        //public bool IsAdmin { get; set; }
        public bool IsBlocked { get; set; }
        public ICollection<PersonalCollection> Collections { get; } = [];

        //https://learn.microsoft.com/ru-ru/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-8.0#add-navigation-properties
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
    }

}
