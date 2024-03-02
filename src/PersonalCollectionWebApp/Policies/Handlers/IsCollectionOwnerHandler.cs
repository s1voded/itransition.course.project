using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using PersonalCollectionWebApp.Data;
using PersonalCollectionWebApp.Models.Entities;
using PersonalCollectionWebApp.Policies.Requirements;

namespace PersonalCollectionWebApp.Policies.Handlers
{
    public class IsCollectionOwnerHandler: AuthorizationHandler<AllowedManageCollectionRequirement, PersonalCollection>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IsCollectionOwnerHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, AllowedManageCollectionRequirement requirement, PersonalCollection? resource)
        {
            var user = await _userManager.GetUserAsync(context.User);
            if (user == null)
            {
                return;
            }

            if (resource?.UserId == user.Id)
            {
                context.Succeed(requirement);
            }
        }
    }
}
