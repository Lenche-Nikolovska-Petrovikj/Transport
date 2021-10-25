using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterIoCServices(this IServiceCollection services)
        {
            services.AddScoped<ITransportService, TransportService>();
            
            services.AddScoped<ITransportRepository, TransportRepository>();
        }
    }
}
