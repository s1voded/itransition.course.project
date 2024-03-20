using Microsoft.EntityFrameworkCore;
using PersonalCollection.Application.Interfaces.Repositories;
using PersonalCollection.Domain.Entities;
using PersonalCollection.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCollection.Persistence.Repositories
{
    public class UserRepository : GenericRepository<ApplicationUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        //https://learn.microsoft.com/ru-ru/ef/core/saving/cascade-delete#cascading-nulls
        public async Task ClearUserReactions(string userName)
        {
            var user = await GetAll()
                .Include(u => u.Comments)
                .Include(u => u.Likes)
                .FirstAsync(u => u.UserName == userName);

            user.Comments.Clear();
            user.Likes.Clear();

            await SaveChangesAsync();
        }
    }
}
