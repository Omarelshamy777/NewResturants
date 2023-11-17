using Resturants.Application.Contracts.ResturantApp;
using Resturants.Application.Contracts.ResturantApp.Dtos;
using Resturants.Application.Enums;
using Resturants.DAL.Enums;
using Resturants.DAL.Models;
using Resturants.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Resturants.Application.AppServices
{
    internal class ResturantAppService : IResturantAppService
    {
        private readonly ResturantsContext _resturantContext;
        public ResturantAppService(ResturantsContext resturantContext)
        {
                _resturantContext = resturantContext;
        }
        //ResturantsMenu
        public Task<List<ResturantMenuDto>> GetAllMenus()
        {

            var GetAllMenus = _resturantContext.Resturants.AsNoTracking().Include(c => c.Menus).ThenInclude(d => d.Items).Select(x => new ResturantMenuDto()
            {
                ResturantID = x.Id,
                ResturantName = x.Name
            ,
                Id = x.Menus.Id,
                Name = x.Menus.Name,
                ResturantsMenuItems = x.Menus.Items.Select(y => new ResturantsMenuItemDto()
                {
                    Id = y.Id,
                    Categories = y.Category,
                    Name = y.Name,
                    Price = y.Price
                }).ToList()
            }).ToList();

            return Task.FromResult(GetAllMenus);


        }


        public async Task<Response<ResturantMenuDto>> GetResturantMenu(int resturantId)
        {
            var allMenu = await GetAllMenus();
            return new Response<ResturantMenuDto>
            {
                Data = allMenu.FirstOrDefault(s => s.ResturantID == resturantId)
            };
        }

        public async Task<Response> AddCustomerOrder(OrderRequestDto OrderRequest)
        {


            List<Contracts.ResturantApp.Dtos.Item> Items = new List<Contracts.ResturantApp.Dtos.Item>();
            var obj = new Order
            {
                Items = OrderRequest.Items.Select(x => new DAL.Models.Item() { Id = x.Id, Name = x.Name, Price = x.Price }).ToList()
                ,
                //OrderStaus = OrderRequest.OrderStaus,
                //TotalPrice =


                //OrderNumber = OrderRequest.OrderNumber,
                //OrderStaus = OrderStatusEnum.Open,
                //TotalPrice = OrderRequest.Price,

                Customer = new Customer()
                {
                    Id = OrderRequest.CustomerId,
                    Name = OrderRequest.CustomerName,
                },



            };

            if (OrderRequest.OrderStaus != OrderStatus.WaitingForDelivery)
            {
                var AddOrder = _resturantContext.Oreders.AddAsync(obj);
                if (AddOrder.IsCompleted)
                {
                    await _resturantContext.SaveChangesAsync();
                    return new Response
                    {
                        ResponseCode = ResponseType.Success,
                        Message = "Order Added Succisfully"
                    };
                }
                else
                {

                    return new Response
                    {
                        Message = "Error in Added Order"
                    };
                }

            }
            else
            {
                return new Response
                {
                    Message = "cant update Order  is inprogress Please add a new one "
                };
            }
        }

        public async Task<Response> GetOrder(int OrderId)
        {

            var GetOrder = _resturantContext.Oreders.Include(c => c.Items).Include(d => d.Customer).ToList().Where(v => v.Id == OrderId);
            return new Response { Data = GetOrder };


        }

        public async Task<Response> Delete(int Orderid)
        {
            var item = await _resturantContext.Oreders.FindAsync(Orderid);

            if (item == null)
            {
                return new Response
                {
                    Message = "Error in deleting Order"
                };
            }
            _resturantContext.Oreders.Remove(item);
            await _resturantContext.SaveChangesAsync();

            return new Response
            {
                Message = "Order is deleted"
            };
        }


        public async Task<Response> SendOrder(int Orderid)
        {
            var item = await _resturantContext.Oreders.FindAsync(Orderid);

            if (item == null)
            {
                return new Response
                {
                    Message = "Error in deleting Order"
                };
            }
            item.OrderStaus = OrderStatus.WaitingForDelivery;
            _resturantContext.Oreders.Update(item);
            await _resturantContext.SaveChangesAsync();

            return new Response
            {
                Message = "Order is Updated"
            };
        }

        public async Task<Response> CancelOrder(int Orderid)
        {
            var item = await _resturantContext.Oreders.FindAsync(Orderid);
            if (item == null)
            {
                return new Response
                {
                    Message = "Error in Canceling Order"
                };
            }
            item.OrderStaus = OrderStatus.Cancelled;
            _resturantContext.Oreders.Update(item);
            await _resturantContext.SaveChangesAsync();
            return new Response
            {
                Message = "Order is Cancelled"
            };
        }

    }
}
