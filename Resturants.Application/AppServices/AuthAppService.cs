
using Microsoft.EntityFrameworkCore;
using Resturants.Application.Contracts.AuthApp;
using Resturants.Application.Contracts.AuthApp.Dtos;
using Resturants.Application.Contracts.ResturantApp.Dtos;
using Resturants.Application.Enums;
using Resturants.DAL;
using Resturants.DAL.Enums;
using Resturants.DAL.Models;


namespace Resturants.Application.AppServices
{

    internal class AuthAppService : IAuthAppService
    {
        private readonly ResturantsContext _resturantContext;

        //private readonly UserManager<IdentityUser> _userManager;
        public AuthAppService(ResturantsContext resturantContext/*, UserManager<IdentityUser> userManager*/)
        {
            //_userManager = userManager;
            _resturantContext = resturantContext;
        }

        public async Task<Response> SignUp(SignUpDto SignUP)
        {
            var obj = new Customer()
            {

                Name = SignUP.Name,
                UserName = SignUP.UserName,
                Password = SignUP.Password
            };

            var AddCustomer = _resturantContext.AddAsync(obj);

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

        public async Task<Response> Authenticate(LoginDto login)
        {

            var GetcustomerId = _resturantContext.Customers.Where(x => x.Id == login.UserId).FirstOrDefault();

            var CustomerPassword = _resturantContext.Customers.Where(x => x.UserName == login.userName && x.Password == login.Password).FirstOrDefault();



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
        public Task<List<ResturantsMenuDto>> GetAllMenus()
        {

            var GetAllMenus = _resturantContext.Resturants.AsNoTracking().Include(c => c.Menus).ThenInclude(d => d.Items).Select(x => new ResturantsMenuDto()
            {
                ResturantID = x.ResturantID,
                ResturantName = x.ResturantName
            ,
                MenuId = x.Menus.MenuId,
                MenuName = x.Menus.MenuName,
                ResturantsMenuItems = x.Menus.Items.Select(y => new ResturantsMenuItemDto()
                {
                    ItemId = y.Id,
                    Categories = y.Category,
                    ItemName = y.Name,
                    ItemPrice = y.Price
                }).ToList()
            }).ToList();

            return Task.FromResult(GetAllMenus);


        }


        public async Task<Response<ResturantsMenuDto>> GetResturantMenu(int resturantId)
        {
            var allMenu =await GetAllMenus();
            return new Response<ResturantsMenuDto>
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

            var GetOrder = _resturantContext.Oreders.Include(c => c.Items).Include(d => d.Customer).ToList().Where(v => v.OrderId == OrderId);
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
