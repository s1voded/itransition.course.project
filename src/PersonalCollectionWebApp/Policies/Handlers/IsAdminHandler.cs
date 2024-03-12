using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonalCollection.Domain;
using PersonalCollection.Domain.Entities;
using PersonalCollectionWebApp.Data;
using PersonalCollectionWebApp.Policies.Requirements;
using System.Security.Claims;

namespace PersonalCollectionWebApp.Policies.Handlers
{
    public class IsAdminHandler : IAuthorizationHandler
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IsAdminHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task HandleAsync(AuthorizationHandlerContext context)
        {
            var pendingRequirements = context.PendingRequirements.ToList();

            foreach (var requirement in pendingRequirements)
            {
                if (requirement is IsAdminRequirement || requirement is AllowedManageCollectionRequirement)
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
    }
}
