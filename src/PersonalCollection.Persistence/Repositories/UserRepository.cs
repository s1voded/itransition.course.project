using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonalCollection.Application.Interfaces.Repositories;
using PersonalCollection.Domain.Entities;
using PersonalCollection.Persistence.Contexts;

namespace PersonalCollection.Persistence.Repositories
{
    public class UserRepository : GenericRepository<ApplicationUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        //https://learn.microsoft.com/ru-ru/ef/core/saving/execute-insert-update-delete
        public async Task<int> ExecuteUpdateUsersBlockStatus(string[] userIds, bool status)
        {
            return await GetAll()
                .Where(u => userIds.Contains(u.Id))
                .ExecuteUpdateAsync(setters => setters.SetProperty(u => u.IsBlocked, status));
        }

        public async Task AddUsersClaim(string[] userIds, string claimType, string claimValue)
        {
            var users = await GetUsersWithClaims(userIds);
            foreach (var user in users)
            {
                if (!UserHasClaim(user, claimType, claimValue))
                {
                    var claim = new IdentityUserClaim<string>() { UserId = user.Id, ClaimType = claimType, ClaimValue = claimValue };
                    user.Claims.Add(claim);
                }
            }
        }

        public async Task RemoveUsersClaim(string[] userIds, string claimType, string claimValue)
        {
            var users = await GetUsersWithClaims(userIds);
            foreach (var user in users)
            {
                if (UserHasClaim(user, claimType, claimValue))
                {
                    var claims = user.Claims.Where(c => c.ClaimType == claimType && c.ClaimValue == claimValue);
                    foreach (var claim in claims)
                    {
                        user.Claims.Remove(claim);
                    }
                }
            }
        }

        public async Task<int> ExecuteDeleteUsers(string[] userIds)
        {
            await ClearUsersReactions(userIds);
            return GetAll()
                .Where(u => userIds.Contains(u.Id))
                .ExecuteDelete();
        }

        private async Task ClearUsersReactions(string[] userIds)
        {
            var users = await GetAll()
                .Include(u => u.Comments)
                .Include(u => u.Likes)
                .Where(u => userIds.Contains(u.Id))
                .ToListAsync();

            foreach (var user in users)
            {
                user.Comments.Clear();
                user.Likes.Clear();
            }
            await SaveChangesAsync();
        }

        private bool UserHasClaim(ApplicationUser user, string claimType, string claimValue)
        {
            return user.Claims
                .Where(c => c.ClaimType == claimType)
                .Any(c => c.ClaimValue == claimValue);
        }

        private async Task<IEnumerable<ApplicationUser>> GetUsersWithClaims(string[] userIds)
        {
            return await GetAll()
                .Include(u => u.Claims)
                .Where(u => userIds.Contains(u.Id))
                .ToListAsync();
        }
    }
}
