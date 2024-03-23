using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using PersonalCollection.Domain.Entities;
using PersonalCollectionWebApp.Policies.Requirements;

namespace PersonalCollectionWebApp.Policies.Handlers
{
    public class IsCollectionOwnerHandler: AuthorizationHandler<AllowedManageCollectionRequirement, string>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IsCollectionOwnerHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, AllowedManageCollectionRequirement requirement, string authorId)
        {
            var user = await _userManager.GetUserAsync(context.User);
            if (user == null)
            {
                return;
            }

            if (authorId == user.Id)
            {
                context.Succeed(requirement);
            }
        }
    }
}
