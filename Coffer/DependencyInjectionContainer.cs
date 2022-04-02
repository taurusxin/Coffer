using Coffer.Interfaces;
using Coffer.Services;
using Coffer.Tools;
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
            services.AddSingleton<IHistoryService, HistoryService>();
            services.AddSingleton<Util>();

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
            services.AddTransient<AddHistoryPageViewModel>();
            services.AddTransient<HistoryPageViewModel>();
            services.AddTransient<SettingPageViewModel>();
            
            return services;
        }
    }
}