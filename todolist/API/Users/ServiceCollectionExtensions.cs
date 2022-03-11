using API.Todo;
using Microsoft.Extensions.DependencyInjection;

namespace API.Users
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUsers(this IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserRepository>();
            return services;
        }
    }
}
