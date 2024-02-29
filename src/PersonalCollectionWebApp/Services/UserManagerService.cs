using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private IEnumerable<ApplicationUser> users;

        public UserManagerService(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ApplicationUserDto>> GetAllUsers()
        {
            users = await _userManager.Users.Include(u => u.Claims).ToListAsync();
            return _mapper.Map<IEnumerable<ApplicationUserDto>>(users);
            //return await _userManager.Users.Include(u => u.Claims).ProjectTo<ApplicationUserDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task AddUserRole(string userId, string role)
        {
            var user = await GetUserById(userId);
            if (user != null) 
            {
                if(!UserHasClaim(user, ClaimTypes.Role, role))
                {
                    var claimRole = new Claim(ClaimTypes.Role, role);
                    await _userManager.AddClaimAsync(user, claimRole);
                }
            }        
        }

        public async Task RemoveUserRole(string userId, string role)
        {
            var user = await GetUserById(userId);
            if (user != null)
            {
                if (UserHasClaim(user, ClaimTypes.Role, role))
                {
                    var claimRole = new Claim(ClaimTypes.Role, role);
                    await _userManager.RemoveClaimAsync(user, claimRole);
                }
            }
        }

        private async Task<ApplicationUser> GetUserById(string userId)
        {
            return await _userManager.Users.Include(u => u.Claims).FirstOrDefaultAsync(u => u.Id == userId);
            //return users.FirstOrDefault(u => u.Id == userId);
        }

        private bool UserHasClaim(ApplicationUser user, string claimType, string claimValue)
        {
            return user.Claims.Where(c => c.ClaimType == claimType).Any(c => c.ClaimValue == claimValue);
        }
    }
}
