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
    }

}
