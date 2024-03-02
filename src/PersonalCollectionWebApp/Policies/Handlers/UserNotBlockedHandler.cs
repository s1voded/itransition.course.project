using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonalCollectionWebApp.Data;
using PersonalCollectionWebApp.Policies.Requirements;
using System.Security.Claims;

namespace PersonalCollectionWebApp.Policies.Handlers
{
    public class UserNotBlockedHandler : AuthorizationHandler<UserNotBlockedRequirement>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserNotBlockedHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, UserNotBlockedRequirement requirement)
        {
            var user = await _userManager.GetUserAsync(context.User);
            if (user == null)
            {
                context.Succeed(requirement);
                return;
            }

            if (!user.IsBlocked)
            {
                context.Succeed(requirement);
            }
        }
    }
}
