using DonateBlood.Application.Services.Donations;
using DonateBlood.Application.Services.Donors;
using DonateBlood.Application.Services.Stock;
using Microsoft.Extensions.DependencyInjection;

namespace DonateBlood.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddServices();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IDonationsService, DonationService>();
            services.AddScoped<IDonorsService, DonorsService>();
            services.AddScoped<IStockService, StockService>();

            return services;
        }

    }
}
