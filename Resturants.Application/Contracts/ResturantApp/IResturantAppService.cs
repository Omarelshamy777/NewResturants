using Resturants.Application.Contracts.ResturantApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Contracts.ResturantApp
{
    public interface IResturantAppService
    {
        //public  Task<Response> GetAllMenus();
        public Task<List<ResturantMenuDto>> GetAllMenus();

        public Task<Response> AddCustomerOrder(OrderRequestDto orderRequest);

        public Task<Response<ResturantMenuDto>> GetResturantMenu(int resturantId);

        public Task<Response> Delete(int orderId);

        public Task<Response> SendOrder(int orderId);
        public Task<Response> CancelOrder(int Orderid);

    }
}
