
using DAL;
using DAL.Models;
using DTO;

using Microsoft.EntityFrameworkCore;
using NewResturants.Enums;
using Resturant.Business.Interfaces;

using System;
using System.Collections.Generic;

using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Business.Managers
{

    public class AuthManager : IAuthManager
    {
        private readonly ResturantsContext _resturantContext;

        //private readonly UserManager<IdentityUser> _userManager;
        public AuthManager(ResturantsContext resturantContext/*, UserManager<IdentityUser> userManager*/)
        {
            //_userManager = userManager;
            _resturantContext = resturantContext;
        }

        public async Task<Response> SignUp(SignUPVM SignUP)
        {
            var obj = new Customer()
            {

                Name = SignUP.Name,
                userName = SignUP.UserName,
                Password = SignUP.Password
            };

            var AddCustomer = _resturantContext.AddAsync<Customer>(obj);

            if (AddCustomer.IsCompleted)
            {
                await _resturantContext.SaveChangesAsync();
                var response = new Response()
                {

                    Success = true,
                    Message = "Sign up successful!"
                };
                return response;
            }


            return new Response
            {

                Success = false,
                Message = "Sign up Failed!"
            };


        }

        public async Task<Response> Authenticate(LoginVM login)
        {

            var GetcustomerId = _resturantContext.Customers.Where(x => x.CustomerID == login.UserId).FirstOrDefault();

            var CustomerPassword = _resturantContext.Customers.Where(x => x.userName == login.userName && x.Password == login.Password).FirstOrDefault();



            if (CustomerPassword == null)
            {

                return new Response
                {
                    Success = false,
                    Message = "please check username and passowrd"
                };
            }
            else
            {

                return new Response
                {
                    Success = true,
                    Message = "logged in succesfully"

                };

            }
        }

        //ResturantsMenu
        public async Task<Response> GetAllMenus()
        {

            var GetAllMenus = await _resturantContext.Resturants.Include(c=>c.Menus).ThenInclude(d=>d.Foods).ToListAsync();
            //var GetAllMenusWIthFooda = await _resturantContext.Foods.Include(x => x.Resturants).ToListAsync();

            return new Response
            {
                Data = GetAllMenus
            };


        }


        public async Task<Response> GetResturantMenu(int resturantId)
        {
            var restaurantMenu = await _resturantContext.Resturants.Include(x => x.Orders).FirstOrDefaultAsync(s => s.ResturantID == resturantId);
            return new Response
            {
                Data = restaurantMenu
            };
        }

        public async Task<Response> AddCustomerOrder(OrderRequestVM OrderRequest)
        {

            var obj = new Order
            {
                OrderId = OrderRequest.OrderID,
                OrderNumber = OrderRequest.OrderNumber,
                OrderStaus = OrderStatusEnum.Open,
                TotalPrice = OrderRequest.Price,
                
                Customers  = new Customer
                {
                    CustomerID = OrderRequest.CustomerId,
                    Name = OrderRequest.CustomerName,                    
                },
                Resturants = new DAL.Models.Resturant
                {
                    ResturantID = OrderRequest.ResturantID,

                },Foods = new Food
                {
                    FoodId = OrderRequest.FoodId,
                }
                
               
            };
            if (OrderRequest.OrderStaus != OrderStatusEnum.WaitingForDelivery)
            {
                var AddOrder = _resturantContext.Oreders.AddAsync(obj);
                if (AddOrder.IsCompleted)
                {
                    await _resturantContext.SaveChangesAsync();
                    return new Response
                    {
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

            }else
            {
                return new Response
                {
                    Message = "cant update Order  is inprogress Please add a new one "
                };
            }
        }

        public async Task<Response> GetOrder(int OrderId)
        {

            var GetOrder = _resturantContext.Oreders.Include(c => c.Resturants).Include(d => d.Customers).ToList().Where(v => v.OrderId == OrderId);
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
            item.OrderStaus = OrderStatusEnum.WaitingForDelivery;
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
            item.OrderStaus = OrderStatusEnum.Cancelled;
            _resturantContext.Oreders.Update(item);
            await _resturantContext.SaveChangesAsync();
            return new Response
            {
                Message = "Order is Cancelled"
            };
        }

    }
}
