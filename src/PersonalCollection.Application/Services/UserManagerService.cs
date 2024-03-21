using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonalCollection.Application.Interfaces.Repositories;
using PersonalCollection.Application.Models;
using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.Services
{
    public class UserManagerService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserManagerService(UserManager<ApplicationUser> userManager, IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<ApplicationUserDto>> GetAllUsers()
        {
            return await _userRepository.GetAll()
                .Include(u => u.Claims)
                .ProjectTo<ApplicationUserDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task UpdateUsersBlockStatus(string[] userIds, bool status) => await _userRepository.ExecuteUpdateUsersBlockStatus(userIds, status);
        public async Task DeleteUsers(string[] userIds) => await _userRepository.ExecuteDeleteUsers(userIds);

        public async Task AddUsersClaim(string[] userIds, string claimType, string claimValue)
        {
            await _userRepository.AddUsersClaim(userIds, claimType, claimValue);
            await _userRepository.SaveChangesAsync();
        }

        public async Task RemoveUsersClaim(string[] userIds, string claimType, string claimValue)
        {
            await _userRepository.RemoveUsersClaim(userIds, claimType, claimValue);
            await _userRepository.SaveChangesAsync();
        }
    }
}
