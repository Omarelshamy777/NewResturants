using DAL;
using DAL.Models;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resturant.Business;
using Resturant.Business.Interfaces;

namespace NewResturants.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IAuthManager authManager;
        private readonly ResturantsContext _resturantContext;

        public HomeController(IAuthManager authManager, ResturantsContext resturantContext)
        {
            this.authManager = authManager;
            _resturantContext = resturantContext;
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
        public async Task<IActionResult> getAllMenus()
        {

            //HttpContext.Session.Set<LoginVM>("Login", Login);
            var customerSignUp = await authManager.GetAllMenus();
            //var GetAllMenus = await _resturantContext.Resturants.Include(c => c.Menus).ThenInclude(d => d.Foods).ToListAsync();
            return Ok(customerSignUp);
        }

        [HttpPost("AddOrder")]
        public async Task<Response> AddOrder(OrderRequestVM OrderRequest)
        {

            var customerSignUp = await authManager.AddCustomerOrder(OrderRequest);
            return customerSignUp;
        }

        [HttpGet("getResturantMenu")]
        public async Task<IActionResult> getResturantMenu(int ResturantId)
        {
         
            var customerSignUp = await authManager.GetResturantMenu(ResturantId);
            return Ok(customerSignUp.Data);
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
