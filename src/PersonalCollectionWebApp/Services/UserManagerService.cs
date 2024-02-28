using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonalCollectionWebApp.Data;
using System.Security.Claims;

namespace PersonalCollectionWebApp.Services
{
    public class UserManagerService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private IEnumerable<ApplicationUser> users;
        //public IEnumerable<ApplicationUser> Users => users;

        public UserManagerService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsers()
        {
            users = await _userManager.Users.Include(u => u.Claims).ToListAsync();
            return users;
        }

        public string GetUserRoles(ApplicationUser user)
        {
            var roleClaims = user.Claims.Where(c => c.ClaimType == ClaimTypes.Role).ToList();
            return string.Join(",", roleClaims.Select(r => r.ClaimValue));
        }
    }
}
