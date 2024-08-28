using ProjectUsers.Data.Context;
using ProjectUsers.Domain.Repositories;

namespace ProjectUsers.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {        
        private readonly AppDbContext _appDbContext;
        private IUserRepository _userRepository;       

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IUserRepository UserRepository => _userRepository ?? new UserRepository(_appDbContext);


        public async Task CommitAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _appDbContext?.Dispose();
        }
    }
}
