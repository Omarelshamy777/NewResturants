
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

     

    }
}
