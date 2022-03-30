using Coffer.Interfaces;
using Coffer.Services;
using Coffer.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Coffer
{
    public static class DependencyInjectionContainer
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddSingleton<IDbService, DbService>();
            
            services.AddSingleton<IBrandService, BrandService>();
            services.AddSingleton<ICoffeeService, CoffeeService>();
            services.AddSingleton<IContentService, ContentService>();

            return services;
        }

        public static IServiceCollection ConfigureMockServices(this IServiceCollection services)
        {
            // add mock services here
            
            return services;
        }

        public static IServiceCollection ConfigureViewModels(this IServiceCollection services)
        {
            services.AddTransient<HomePageViewModel>();
            services.AddTransient<CoffeeListPageViewModel>();
            services.AddTransient<CoffeeDetailPageViewModel>();
            
            return services;
        }
    }
}