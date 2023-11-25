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

        public Task<List<ResturantDto>> GetAllMenus();

        public Task<Response> AddCustomerOrder(OrderDto orderRequest);

        public Task<Response<GetCustomerOrderDto>> GetCustomerOrder(int OrderId);
        public  Task<Response> EditOrder(OrderDto orderRequest);




        public Task<Response<ResturantDto>> GetResturantMenu(int resturantId);

        public Task<Response> Delete(int orderId);

        public Task<Response> SendOrder(int orderId);
        public Task<Response> CancelOrder(int orderid);

    }
}
