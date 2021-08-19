using System;
using Application;
using Data;
using Infrastructure;
using Abstractions.Application;
using Abstractions.DataServices;
using Abstractions.Domain;
using Abstractions.Infrastructure;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Resolver
{
    public static class FoodTruckResolver
    {
        public static IServiceCollection AddFoodTruck(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddScoped<IConfigureConnection, ConfigureConnectionSqlLite>()
                .AddContext<IFoodTruckServices, FoodTruckContext>()
                .AddScoped<IFoodTruck, FoodTruck>()
                .AddScoped<IFoodTruckDomain, FoodTruckDomain>();
        }

        private static IServiceCollection AddContext<TServices, TContext>(this IServiceCollection serviceCollection)
            where TContext : DbContext, TServices
            where TServices : class
        {
            return serviceCollection
                .AddDbContext<TContext>(ConfigureConnection)
                .AddScoped<TServices, TContext>();
        }

        private static void ConfigureConnection(IServiceProvider provider, DbContextOptionsBuilder obj)
        {
            var configure = provider.GetRequiredService<IConfigureConnection>();
            configure.Configure(obj);
        }
    }
}