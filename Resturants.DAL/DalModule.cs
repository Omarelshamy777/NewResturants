using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.DAL
{
    public class DalModule
    {
        public static void ConfigureService(IServiceCollection services, string connectionString)
        {
            //Connection String
            services.AddDbContext<ResturantsContext>(
                options =>
                options.UseSqlServer(
                    connectionString
                ));
        }
    }
}
