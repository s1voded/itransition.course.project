﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonalCollection.Application.Interfaces.Repositories;
using PersonalCollection.Application.Models;
using PersonalCollection.Domain.Entities;
using System.Data;
using System.Security.Claims;

namespace PersonalCollection.Application.Services
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
            return await _userManager.Users
                .Include(u => u.Claims)
                .ProjectTo<ApplicationUserDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task AddUserRole(string userId, string role)
        {
            var user = await GetUserByIdWithClaims(userId);
            if (user != null && !UserHasClaim(user, ClaimTypes.Role, role))
            {
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, role));
            }
        }

        public async Task RemoveUserRole(string userId, string role)
        {
            var user = await GetUserByIdWithClaims(userId);
            if (user != null && UserHasClaim(user, ClaimTypes.Role, role))
            {
                await _userManager.RemoveClaimAsync(user, new Claim(ClaimTypes.Role, role));
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
            var user = await _userManager.Users
                .Include(u => u.Comments)
                .Include(u => u.Likes)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user != null)
            {
                //https://learn.microsoft.com/ru-ru/ef/core/saving/cascade-delete#cascading-nulls
                user.Comments.Clear();
                user.Likes.Clear();              

                await _userManager.DeleteAsync(user);
            }
        }

        private async Task<ApplicationUser?> GetUserByIdWithClaims(string userId)
        {
            return await _userManager.Users
                .Include(u => u.Claims)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }

        private bool UserHasClaim(ApplicationUser user, string claimType, string claimValue)
        {
            return user.Claims
                .Where(c => c.ClaimType == claimType)
                .Any(c => c.ClaimValue == claimValue);
        }
    }
}
