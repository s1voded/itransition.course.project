using PersonalCollection.Application.Models.Dto;

namespace PersonalCollection.Application.Interfaces.Services
{
    public interface IUserManagerService
    {
        public Task<ApplicationUserDto?> GetUserById(string userId);
        public Task<IEnumerable<ApplicationUserDto>> GetAllUsers();
        public Task DeleteUsers(string[] userIds);

        public Task AddUsersClaim(string[] userIds, string claimType, string claimValue);
        public Task RemoveUsersClaim(string[] userIds, string claimType, string claimValue);

        public Task UpdateUsersBlockStatus(string[] userIds, bool status);

    }
}
