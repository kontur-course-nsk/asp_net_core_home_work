using System;
using System.Threading;
using System.Threading.Tasks;
using API.Auth;
using API.Todo;
using Microsoft.AspNetCore.Mvc;
using API.Users;
using View.Users;

namespace API.Controllers
{
    [Route("users")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IAuthenticator authenticator;

        public AuthController(IUserRepository userRepository, IAuthenticator authenticator)
        {
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.authenticator = authenticator ?? throw new ArgumentNullException(nameof(authenticator));
        }
        
       /* [HttpGet]
        public async Task<ActionResult> GetAllUsers(
            CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

           
            var todoList = new UserList()\\ { Users = await this.userRepository.GetAllUsersAsync(token).ConfigureAwait(false) };
            return this.Ok(todoList);
        }
        */

        [HttpGet("{login}")]
        public async Task<ActionResult> GetAsync(string login, CancellationToken token)
        {
            try
            {
                var user = await this.userRepository.GetAsync(login, token).ConfigureAwait(false);
                return this.Ok(user);
            }
            catch (TodoNotFoundException)
            {
                return this.NotFound();
            }
        }
        
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(  
            [FromBody] UserRegistrationInfo registrationInfo,
            CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            
            var creationInfo = new UserCreationInfo()
            {
                Login = registrationInfo.Login,
                PasswordHash = registrationInfo.Password.GetHashCode().ToString(),
            };
            
            try
            {
                var userInfo = await this.userRepository.CreateAsync(creationInfo, token).ConfigureAwait(false);
                return this.Ok(userInfo);
            }
            catch (ValidationException ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login()
        {
            //найти userinfo 
            //
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            throw new NotImplementedException();
        }
    }
}