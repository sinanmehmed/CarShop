using CarShop.Core.Contracts;
using CarShop.Core.Exceptions;
using CarShop.Core.Services;
using CarShop.Infrastructure.Data.Common;
using System.Runtime.CompilerServices;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CarShopServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IDealerService, DealerService>();
            services.AddScoped<IGuard, Guard > ();
            services.AddScoped<IServiceBookingService, ServiceBookingService>();

            return services;
        }
    }
}
