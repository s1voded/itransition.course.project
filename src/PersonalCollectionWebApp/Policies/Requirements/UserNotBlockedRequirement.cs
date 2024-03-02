using Microsoft.AspNetCore.Authorization;

namespace PersonalCollectionWebApp.Policies.Requirements
{
    public class UserNotBlockedRequirement : IAuthorizationRequirement 
    {
        public UserNotBlockedRequirement(bool allowAnonymous)
        {
            AllowAnonymous = allowAnonymous;
        }
        public bool AllowAnonymous { get; }
    }
}
