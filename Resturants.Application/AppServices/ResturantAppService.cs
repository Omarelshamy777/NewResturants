﻿using Resturants.Application.Contracts.ResturantApp;
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
using Castle.Core.Resource;
using System.Net.NetworkInformation;

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
        public Task<List<ResturantDto>> GetAllMenus()
        {

            var GetAllMenus = _resturantContext.Resturants.AsNoTracking().Include(c => c.Menus).ThenInclude(d => d.Items).Select(x => new ResturantDto()
            {
                Id = x.Id,
                 Name = x.Name
            ,
                Menu = new MenuDto(){ Id = x.Menus.Id,
                Name = x.Menus.Name ,
                    Items = x.Menus.Items.Select(y => new ItemDto()
                    {
                        Id = y.Id,
                        Categories = y.Category,
                        Name = y.Name,
                        Price = y.Price
                    }).ToList()


                }
                ,
              
            }).ToList();

            return Task.FromResult(GetAllMenus);


        }


        public async Task<Response<ResturantDto>> GetResturantMenu(int resturantId)
        {
            var allMenu = await GetAllMenus();
            return new Response<ResturantDto>
            {
                Data = allMenu.FirstOrDefault(s => s.Id == resturantId)
            };
        }

        public async Task<Response> AddCustomerOrder(OrderDto orderRequest)
        {
            var GetItemsId = orderRequest.Items.Select(x => x.Id).ToList();
            var GetItemsQuantity = orderRequest.Items.Select(x => x.Quantity).ToList();

            var GetItemPrices = _resturantContext.Items.
                Select(x => new ItemDto { Price = x.Price, Id = x.Id })
                .Where(x => GetItemsId.Contains(x.Id))
                .ToList();

            double TotalPrice = 0;
            double ItemTotalPrice = 0;
            int i = 0;
            
            foreach (var item in GetItemPrices ) {
   
                    TotalPrice += (item.Price * GetItemsQuantity[i]);
                item.Quantity = GetItemsQuantity[i];
                item.TotalPrice = (item.Price * GetItemsQuantity[i]);
                i++;
                
            }
         


            var obj = new Order
            {
                ItemOrder = orderRequest.Items.Select(x => new DAL.Models.ItemOrder() { ItemId = x.Id }).ToList(),
                
                TotalPrice = TotalPrice,
                OrderStaus = orderRequest.Status.Value,
                CustomerID = orderRequest.CustomerId,
                //ResturantId = orderRequest.ResturantId
               

            };

            if (orderRequest.Status != OrderStatus.WaitingForDelivery)
            {
                var AddOrder = _resturantContext.Oreders.AddAsync(obj);
             
                if (AddOrder.IsCompleted)
                {
                    await _resturantContext.SaveChangesAsync();

 
                    var getOrderId = obj.Id;
                    return new Response
                    {
                        ResponseCode = ResponseType.Success,
                        Data = getOrderId,
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

        public async Task<Response<GetCustomerOrderDto>> GetCustomerOrder(int OrderId)
        {
            var GetOrder =  await _resturantContext.Oreders.AsNoTracking().Include(w => w.ItemOrder).ThenInclude(c => c.Item).Select(x => new GetCustomerOrderDto() { OrderId = x.Id, Item = x.ItemOrder.Select(a => new ItemDto() { Id = a.Item.Id ,Name = a.Item.Name , Categories = a.Item.Category , Price = a.Item.Price}).ToList() }).Where(x => x.OrderId == OrderId).FirstOrDefaultAsync() ;

            if (GetOrder != null)
            {
                return new Response<GetCustomerOrderDto> { Data = GetOrder, ResponseCode = ResponseType.Success };
            }
            else
            {
                return new Response<GetCustomerOrderDto>();
            }
           
   

        }

        public async Task<Response> EditOrder(OrderDto orderRequest)
        {
            var GetOrderCustomerId =  _resturantContext.Oreders.Select(x=>new OrderDto() {CustomerId = x.CustomerID , Status = x.OrderStaus }).Where(c=>c.CustomerId == orderRequest.CustomerId).FirstOrDefault();
         

            

if (GetOrderCustomerId.CustomerId == orderRequest.CustomerId)
            {
                if (GetOrderCustomerId.Status == OrderStatus.Open)
                {

                    var obj = new Order
                    {
                        Id = orderRequest.Id.Value,
                        ItemOrder = orderRequest.Items.Select(x => new DAL.Models.ItemOrder() { ItemId = x.Id }).ToList(),
                        TotalPrice = orderRequest.Price,
                        OrderStaus = orderRequest.Status.Value,
                        CustomerID = orderRequest.CustomerId,
                        //ResturantId = orderRequest.ResturantId


                    };
                    var AddOrder = _resturantContext.Oreders.Update(obj);
                    await _resturantContext.SaveChangesAsync();
                    var getOrderId = obj.Id;
                    return new Response
                    {
                        ResponseCode = ResponseType.Success,
                        Data = getOrderId,
                        Message = "Order Updated Succesfully"
                    };
                }
                else
                {
                    return new Response
                    {
                        ResponseCode = ResponseType.Success,
                        Message = "the order is being delevered so you cant update on it please request another one"
                    };

                }

            }
            else
            {
                return new Response
                {
                    ResponseCode = ResponseType.Success,
                    Message = "Only one customer who can update in this order the one who requested the order"
                };



            }

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
                    Message = "Error in sending Order"
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
