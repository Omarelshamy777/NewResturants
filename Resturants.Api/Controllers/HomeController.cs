using Microsoft.AspNetCore.Mvc;
using Resturants.Application;
using Resturants.Application.Contracts.AuthApp;
using Resturants.Application.Contracts.AuthApp.Dtos;
using Resturants.Application.Contracts.ResturantApp;
using Resturants.Application.Contracts.ResturantApp.Dtos;


namespace Resturants.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IAuthAppService authManager;
        private readonly IResturantAppService resturantAppService;


        public HomeController(IAuthAppService authManager , IResturantAppService resturantAppService)
        {
            this.authManager = authManager;
            this.resturantAppService = resturantAppService; 
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


        [HttpGet("getAllMenus")]
        public async Task<IActionResult> GetAllMenus()
        {
            var customerSignUp = await resturantAppService.GetAllMenus();

            return Ok(customerSignUp);
        }

        [HttpPost("AddOrder")]
        public async Task<Response> AddOrder(OrderRequestDto orderRequest)
        {

            var customerSignUp = await resturantAppService.AddCustomerOrder(orderRequest);
            return customerSignUp;
        }

        [HttpGet("getResturantMenu")]
        public async Task<IActionResult> GetResturantMenu(int resturantId)
        {

            var customerSignUp = await resturantAppService.GetResturantMenu(resturantId);
            return Ok(customerSignUp.Data);
        }




        [HttpDelete("{id}")]
        public async Task<Response> DeleteOrder(int orderid)
        {
            var DeleteOrder = await resturantAppService.Delete(orderid);
            return DeleteOrder;
        }


        [HttpPost("WaitingForDelivery")]
        public async Task<Response> ChangeOrderStatus(int orderid)
        {
            var SendOrder = await resturantAppService.SendOrder(orderid);
            return SendOrder;
        }
        [HttpPost("cancelOrder")]
        public async Task<Response> CancelOrder(int orderid)
        {
            var SendOrder = await resturantAppService.CancelOrder(orderid);
            return SendOrder;
        }


    }
}
