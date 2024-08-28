using ProjectUsers.Data.Context;
using ProjectUsers.Domain.Entities;
using ProjectUsers.Domain.Repositories;

namespace ProjectUsers.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
