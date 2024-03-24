namespace PersonalCollection.Application.Interfaces.Services
{
    public interface IAuthService
    {
        public Task<bool> IsAllowManageCollection(string authorId);
        public Task<bool> IsUserAdmin();
        public Task<bool> IsUserAuthenticated();
        public Task<string?> GetCurrentUserId();

    }
}
