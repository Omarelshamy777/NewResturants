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

        [HttpPost("AddOrder")]
        public async Task<Response> AddOrder(OrderRequestVM OrderRequest)
        {

            var customerSignUp = await authManager.AddCustomerOrder(OrderRequest);
            return customerSignUp;
        }

        [HttpGet("getResturantMenu")]
        public async Task<Response> getResturantMenu(int ResturantId)
        {
         
            var customerSignUp = await authManager.GetResturantMenu(ResturantId);
            return customerSignUp;
        }




        [HttpDelete("{id}")]
        public async Task<Response> DeleteOrder(int Orderid)
        {
            var DeleteOrder = await authManager.Delete(Orderid);
            return DeleteOrder;
        }


        [HttpPost("WaitingForDelivery")]
        public async Task<Response> ChangeOrderStatus(int Orderid)
        {
            var SendOrder = await authManager.SendOrder(Orderid);
            return SendOrder;
        }
        [HttpPost("cancelOrder")]
        public async Task<Response> cancelOrder(int Orderid)
        {
            var SendOrder = await authManager.CancelOrder(Orderid);
            return SendOrder;
        }
        

    }
}
