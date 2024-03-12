using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using PersonalCollection.Domain.Entities;
using PersonalCollectionWebApp.Policies.Requirements;

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
                if(requirement.AllowAnonymous)
                {
                    context.Succeed(requirement);
                }
                return;
            }

            if (!user.IsBlocked)
            {
                context.Succeed(requirement);
            }
        }
    }
}
