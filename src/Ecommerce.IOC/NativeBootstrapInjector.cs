using Ecommerce.Application.Carts.Services;
using Ecommerce.Application.Products.Profiles;
using Microsoft.Extensions.DependencyInjection;
using SGTC.Infra.Configurations;
using System.Reflection;

namespace SGTC.IOC
{
    public static class NativeBootstrapInjector
    {
        public static void InjectIOC(this IServiceCollection services)
        {
            services.AddCommon();
        }

        public static IServiceCollection AddCommon(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(ProductProfile).GetTypeInfo().Assembly);
            services.ConfigureDatabase("../../database.sqlite");

            services.Scan(scan => scan.
                        FromAssemblyOf<CartsService>()
                        .AddClasses()
                        .AsSelf()
                        .AsImplementedInterfaces()
                        .WithScopedLifetime());

            return services;
        }
    }
}
