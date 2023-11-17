using Resturants.Application;
using Resturants.Application.Contracts.AuthApp.Dtos;
using Resturants.Application.Contracts.ResturantApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Contracts.AuthApp
{
    public interface IAuthAppService
    {
        //public int SignUp(SignUPVM SignUP);

        public Task<Response> SignUp(SignUPDto signUP);

        public Task<Response> Authenticate(LoginDto login);
        //public Task<List<ResturantsMenu>> GetAllMenus();

        //public  Task<Response> GetAllMenus();
        public Task<List<ResturantsMenuDto>> GetAllMenus();

        public Task<Response> GetResturantMenu(int resturantId);
        public Task<Response> AddCustomerOrder(OrderRequestDto orderRequest);

        public Task<Response> Delete(int orderId);

        public Task<Response> SendOrder(int orderId);
        public Task<Response> CancelOrder(int Orderid);



    }
}
