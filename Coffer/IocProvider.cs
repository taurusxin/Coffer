using System;
using Microsoft.Extensions.DependencyInjection;

namespace Coffer
{
    public static class IocProvider
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static IServiceProvider Init()
        {
            ServiceProvider serviceProvider;
           
            serviceProvider = new ServiceCollection()
                .ConfigureServices()
                .ConfigureMockServices()
                .ConfigureViewModels()
                .BuildServiceProvider();

            ServiceProvider = serviceProvider;

            return serviceProvider;
        }
    }
}