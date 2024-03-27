using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using PersonalCollection.Application.Interfaces.Services;
using System.Security.Claims;
using static PersonalCollection.Domain.Constants;

namespace PersonalCollection.Application.Services
{
    public class AuthService: IAuthService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly IAuthorizationService _authorizationService;

        public AuthService(AuthenticationStateProvider authenticationStateProvider, IAuthorizationService authorizationService)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _authorizationService = authorizationService;
        }

        public async Task<bool> IsAllowManageCollection(string authorId)
        {
            var user = await GetCurrentUser();
            if (user is null) return false;
            var isAuthorized = await _authorizationService.AuthorizeAsync(user, authorId, PolicyCanManageCollection);
            return isAuthorized.Succeeded;
        }

        public async Task<bool> IsUserAdmin()
        {
            var user = await GetCurrentUser();
            if (user is null) return false;
            var isAuthorized = await _authorizationService.AuthorizeAsync(user, PolicyAdminOnly);
            return isAuthorized.Succeeded;
        }

        public async Task<bool> IsUserAuthenticated()
        {
            var user = await GetCurrentUser();
            return user?.Identity is { IsAuthenticated: true };
        }

        public async Task<string?> GetCurrentUserId()
        {
            var user = await GetCurrentUser();
            return user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        private async Task<ClaimsPrincipal?> GetCurrentUser()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            return authState?.User;
        }
    }
}
