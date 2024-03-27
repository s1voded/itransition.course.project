using Microsoft.AspNetCore.Identity;

namespace PersonalCollection.Domain.Entities
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public bool IsBlocked { get; set; }

        //https://learn.microsoft.com/ru-ru/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-8.0#add-navigation-properties
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
    }

}
