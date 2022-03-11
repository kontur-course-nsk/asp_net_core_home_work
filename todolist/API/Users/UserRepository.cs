using System;
using System.Collections.Generic;
using System.Linq;
using API.Todo;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace API.Users
{
    using System.Threading;
    using System.Threading.Tasks;
    using View.Users;

    public sealed class UserRepository : IUserRepository
    {
        private readonly IList<User> users;

        public UserRepository()
        {
            this.users = new List<User> { 
                new User(){
                    Id = "4D448355-E91B-4B6C-FC39-499C37F8655F",
                    Login = "qwerty",
                    PasswordHash = "123456".GetHashCode().ToString(),
                 RegisteredAt = DateTime.Now
                },
                new User(){
                    Id = "E91B-4B6C-FC39-499C37F8655F-4D448355",
                    Login = "ivanov",
                    PasswordHash = "qwerty".GetHashCode().ToString(),
                    RegisteredAt = DateTime.Now-TimeSpan.FromDays(2)
                }
            };
        }
        
        public Task<User> GetAsync(string login,CancellationToken cancellationToken) 
        {
            cancellationToken.ThrowIfCancellationRequested();
            
            var result = this.users.FirstOrDefault(it => it.Login == login);

            if (result == null)
            {
                throw new TodoNotFoundException(login);
            }
            
            return Task.FromResult(result);
        }

        public Task<UserList> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public  Task<User> CreateAsync(UserCreationInfo creationInfo, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var createdUser = new User()
            {
                Id = users.Count.ToString(),
                Login = creationInfo.Login,
                PasswordHash = creationInfo.PasswordHash,
                RegisteredAt = DateTime.Now
            };
             users.Add(createdUser);
             
             return Task.FromResult(createdUser);
        }
    }
}
