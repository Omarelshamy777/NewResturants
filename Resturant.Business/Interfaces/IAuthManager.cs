using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Business.Interfaces
{
    public interface IAuthManager
    {
        //public int SignUp(SignUPVM SignUP);

        public Task<Response> SignUp(SignUPVM SignUP);

        public Task<Response> Authenticate(LoginVM login);
        //public Task<List<ResturantsMenu>> GetAllMenus();

        public  Task<Response> GetAllMenus();
        public List<ResturantsMenu> GetResturantMenu(int resturantId);
        //public List<ResturantsMenu> AddOrder(OrderRequestVM OrderRequest);

        public Task<Response> Delete(long id);


    }
}
