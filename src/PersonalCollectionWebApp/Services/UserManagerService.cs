using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonalCollectionWebApp.Data;
using PersonalCollectionWebApp.Models.Dto;

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
    }
}
