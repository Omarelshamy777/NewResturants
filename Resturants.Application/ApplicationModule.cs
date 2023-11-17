using Microsoft.Extensions.DependencyInjection;
using Resturants.Application.AppServices;
using Resturants.Application.Contracts.AuthApp;
using Resturants.Application.Contracts.ResturantApp;


namespace Resturants.Application
{
    public class ApplicationModule
    {
        public static void ConfigureService(IServiceCollection services)
        {
            services.AddScoped<IAuthAppService, AuthAppService>();
            services.AddScoped<IResturantAppService, ResturantAppService>();
        }
    }
}
