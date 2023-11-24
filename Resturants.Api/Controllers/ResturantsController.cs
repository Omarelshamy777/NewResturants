using Microsoft.AspNetCore.Mvc;
using Resturants.Application;
using Resturants.Application.Contracts.AuthApp;
using Resturants.Application.Contracts.AuthApp.Dtos;
using Resturants.Application.Contracts.ResturantApp;
using Resturants.Application.Contracts.ResturantApp.Dtos;
using System.Threading.Tasks;


namespace Resturants.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ResturantsController : ControllerBase
    {

        private readonly IResturantAppService resturantAppService;


        public ResturantsController(IResturantAppService resturantAppService)
        {
            this.resturantAppService = resturantAppService; 
        }

 


        [HttpGet("getAllMenus")]
        public async Task<IActionResult> GetAllMenus()
        {
            var customerSignUp = await resturantAppService.GetAllMenus();

            return Ok(customerSignUp);
        }

        [HttpPost("AddOrder")]
        public async Task<Response> AddOrder(OrderDto orderRequest)
        {

            var customerSignUp = await resturantAppService.AddCustomerOrder(orderRequest);
            return customerSignUp;
        }
        [HttpPost("GetCustomerOrder")]
        public async Task<IActionResult> GetCustomerOrder(int orderId)
        {

            var customerSignUp = await resturantAppService.GetCustomerOrder(orderId);
            return Ok(customerSignUp.Data);
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
