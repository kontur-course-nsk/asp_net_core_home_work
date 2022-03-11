namespace API.Users
{
    using System.Threading;
    using System.Threading.Tasks;
    using View.Users;

    public interface IUserRepository
    {
        Task<User> GetAsync(string login,CancellationToken cancellationToken);

        Task<User> CreateAsync(UserCreationInfo creationInfo, CancellationToken cancellationToken);
    }
}
