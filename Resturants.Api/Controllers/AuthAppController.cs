using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturants.Application;
using Resturants.Application.Contracts.AuthApp;
using Resturants.Application.Contracts.AuthApp.Dtos;

namespace Resturants.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthAppController : ControllerBase
    {
        private readonly IAuthAppService authManager;
        public AuthAppController(IAuthAppService authManager)
        {
            this.authManager = authManager; 
        }
        [HttpPost("signUp")]
        public async Task<Response> SignUp(SignUpDto signUP)
        {
            var customerSignUp = await authManager.SignUp(signUP);
            return customerSignUp;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto login)
        {

            var customer = await authManager.Authenticate(login);
            return Ok(customer);
        }

    }
}
