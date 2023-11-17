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

        public Task<Response> SignUp(SignUpDto signUP);

        public Task<Response> Authenticate(LoginDto login);
     



    }
}
