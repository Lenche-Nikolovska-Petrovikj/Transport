using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Application.ViewModels
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayaer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        }

    }
}
