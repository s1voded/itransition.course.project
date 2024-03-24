using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PersonalCollection.Application.Interfaces.Repositories;
using PersonalCollection.Application.Interfaces.Services;
using PersonalCollection.Application.Models.Dto;

namespace PersonalCollection.Application.Services
{
    public class UserManagerService: IUserManagerService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserManagerService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<ApplicationUserDto>> GetAllUsers()
        {
            return await _userRepository.GetAll()
                .Include(u => u.Claims)
                .ProjectTo<ApplicationUserDto>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
        }

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

        public async Task UpdateUsersBlockStatus(string[] userIds, bool status) => await _userRepository.ExecuteUpdateUsersBlockStatus(userIds, status);
    }
}
