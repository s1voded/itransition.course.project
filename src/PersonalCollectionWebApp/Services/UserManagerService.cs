using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonalCollection.Domain.Entities;
using PersonalCollectionWebApp.Data;
using PersonalCollectionWebApp.Models.Dto;
using System.Data;
using System.Linq;
using System.Security.Claims;

namespace PersonalCollectionWebApp.Services
{
    public class UserManagerService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public UserManagerService(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ApplicationUserDto>> GetAllUsers()
        {
            return await _userManager.Users.Include(u => u.Claims).ProjectTo<ApplicationUserDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task AddUserRole(string userId, string role)
        {
            var user = await GetUserByIdWithClaims(userId);
            if (user != null && !UserHasClaim(user, ClaimTypes.Role, role))
            {
                var claimRole = new Claim(ClaimTypes.Role, role);
                await _userManager.AddClaimAsync(user, claimRole);
            }
        }

        public async Task RemoveUserRole(string userId, string role)
        {
            var user = await GetUserByIdWithClaims(userId);
            if (user != null && UserHasClaim(user, ClaimTypes.Role, role))
            {
                var claimRole = new Claim(ClaimTypes.Role, role);
                await _userManager.RemoveClaimAsync(user, claimRole);
            }
        }

        public async Task UpdateBlockStatusUser(string userId, bool status)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null && user.IsBlocked != status)
            {
                user.IsBlocked = status;
                await _userManager.UpdateAsync(user);
            }
        }

        public async Task DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
        }

        private async Task<ApplicationUser?> GetUserByIdWithClaims(string userId)
        {
            return await _userManager.Users.Include(u => u.Claims).FirstOrDefaultAsync(u => u.Id == userId);
        }

        private bool UserHasClaim(ApplicationUser user, string claimType, string claimValue)
        {
            return user.Claims.Where(c => c.ClaimType == claimType).Any(c => c.ClaimValue == claimValue);
        }
    }
}
