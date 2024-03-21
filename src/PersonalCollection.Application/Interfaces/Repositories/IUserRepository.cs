using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<ApplicationUser>
    {
        public Task<int> ExecuteUpdateUsersBlockStatus(string[] userIds, bool status);
        public Task<int> ExecuteDeleteUsers(string[] userIds);
        public Task AddUsersClaim(string[] userIds, string claimType, string claimValue);
        public Task RemoveUsersClaim(string[] userIds, string claimType, string claimValue);
    }
}
