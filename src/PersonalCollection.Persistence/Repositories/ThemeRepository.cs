using PersonalCollection.Application.Interfaces.Repositories;
using PersonalCollection.Domain.Entities;
using PersonalCollection.Persistence.Contexts;

namespace PersonalCollection.Persistence.Repositories
{
    public class ThemeRepository : GenericRepository<Theme>, IThemeRepository
    {
        public ThemeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
