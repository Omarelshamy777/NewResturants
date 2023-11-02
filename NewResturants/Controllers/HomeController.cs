using DAL.Models;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant.Business;
using Resturant.Business.Interfaces;

namespace NewResturants.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IAuthManager authManager;

        public HomeController(IAuthManager authManager)
        {
            this.authManager = authManager;
        }

        [HttpPost("signUp")]
        public async Task<Response> signUp(SignUPVM SignUP)
        {
            var customerSignUp = await authManager.SignUp(SignUP);
            return customerSignUp;
        }


        [HttpPost("login")]
        public async Task<Response> login(LoginVM Login)
        {

            //HttpContext.Session.Set<LoginVM>("Login", Login);
            var customer = await authManager.Authenticate(Login);
            return customer;
        }


        [HttpGet("getAllMenus")]
        public async Task<Response> getAllMenus()
        {

            //HttpContext.Session.Set<LoginVM>("Login", Login);
            var customerSignUp = await authManager.GetAllMenus();
            return customerSignUp;
        }

        [HttpGet("getResturantMenu")]
        public async Task<Response> getResturantMenu(int ResturantId)
        {
         
            var customerSignUp = await authManager.GetResturantMenu(ResturantId);
            return customerSignUp;
        }


        [HttpDelete("{id}")]
        public async Task<Response> DeleteOrder(int id)
        {
            var DeleteOrder = await authManager.Delete(id);
            return DeleteOrder;
        }
    }
}
