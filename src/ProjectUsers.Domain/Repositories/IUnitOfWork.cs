namespace ProjectUsers.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        Task CommitAsync();
    }
}