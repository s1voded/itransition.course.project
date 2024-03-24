using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonalCollection.Domain;
using PersonalCollection.Domain.Entities;
using PersonalCollectionWebApp.Policies.Requirements;
using System.Security.Claims;

namespace PersonalCollectionWebApp.Policies.Handlers
{
    public class IsAdminHandler : AuthorizationHandler<IsAdminRequirement>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IsAdminHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, IsAdminRequirement requirement)
        {
            var userId = context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userManager.Users.Include(u => u.Claims).FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                return;
            }
            if (user.Claims.Where(c => c.ClaimType == ClaimTypes.Role).Any(c => c.ClaimValue == Constants.AdminRole))
            {
                context.Succeed(requirement);
            }
        }
    }
}
