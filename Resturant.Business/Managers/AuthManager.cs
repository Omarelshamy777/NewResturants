
using DAL;
using DAL.Models;
using DTO;

using Microsoft.EntityFrameworkCore;
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

            var AddCustomer  = _resturantContext.AddAsync<Customer>(obj);
            
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
              
                return new Response {
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

            //var AllMenus = await _resturantContext.Resturants
            //    .Include(x => x.Foods.Select(f => new ResturantsMenu
            //    {
            //        Categories = f.Categories,
            //        FoodId = f.FoodId,
            //        FoodName = f.FoodName,
            //        ResturantName = x.ResturantName,
            //        ResturantID = x.ResturantID
            //    }).ToList())
            //    .ToListAsync();

            var GetAllMenus = await _resturantContext.Resturants.Include(x=>x.Foods).ToListAsync();
            return new Response
            {
                Data = GetAllMenus

            };


        }





        public List<ResturantsMenu> GetResturantMenu(int resturantId)
        {

            var AllMenus = _resturantContext.Resturants.Include(x => x.Foods.Select(f => new ResturantsMenu { Categories = f.Categories, FoodId = f.FoodId, FoodName = f.FoodName, ResturantName = x.ResturantName, ResturantID = x.ResturantID }).Where(s => s.ResturantID == resturantId).ToList());
            return (List<ResturantsMenu>)AllMenus;

        }

        //public List<ResturantsMenu> AddOrder(OrderRequestVM OrderRequest)
        //{
        //    var GetOrder = _resturantContext.Oreders.Include(c => c.ResturantsName).Include(d => d.CustomerBase).ToList().Where(v => v.OrderId == OrderRequest.OrderID);

        //    var AddOrder = _resturantContext.Oreders.AddAsync(OrderRequest.);
        //    var AllMenus = ;
        //    return (List<ResturantsMenu>)AllMenus;

        //}
  
            public async Task<Response> Delete(long id)
            {
            var item = await _resturantContext.Oreders.FindAsync(id);

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
            } ;
        }

    }
}
