using PersonalCollection.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCollection.Application.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<ApplicationUser>
    {
        public Task ClearUserReactions(string userId);
    }
}
