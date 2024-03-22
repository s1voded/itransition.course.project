using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using PersonalCollection.Domain.Entities;
using System.Security.Claims;
using static PersonalCollection.Domain.Constants;

namespace PersonalCollection.Application.Services
{
    public class AuthService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly IAuthorizationService _authorizationService;

        public AuthService(AuthenticationStateProvider authenticationStateProvider, IAuthorizationService authorizationService)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _authorizationService = authorizationService;
        }

        public async Task<bool> IsAllowManageCollection(Collection collection)
        {
            var user = await GetCurrentUser();
            if (user is not null)
            {
                var isAuthorized = await _authorizationService.AuthorizeAsync(user, collection, PolicyCanManageCollection);
                return isAuthorized.Succeeded;
            }
            return false;
        }

        public async Task<bool> IsUserAdmin()
        {
            var user = await GetCurrentUser();
            if (user is not null)
            {
                var isAuthorized = await _authorizationService.AuthorizeAsync(user, PolicyAdminOnly);
                return isAuthorized.Succeeded;
            }
            return false;
        }

        public async Task<bool> IsUserAuthenticated()
        {
            var user = await GetCurrentUser();
            if (user is not null)
            {
                if (user.Identity is not null && user.Identity.IsAuthenticated)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<string?> GetCurrentUserId()
        {
            var user = await GetCurrentUser();
            if (user is not null)
            {
                return user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }
            return null;
        }

        private async Task<ClaimsPrincipal?> GetCurrentUser()
        {
            if (_authenticationStateProvider is not null)
            {
                var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
                var user = authState?.User;

                return user;
            }
            return null;
        }
    }
}
