using System;
using Data;
using Infrastructure;
using Abstractions.Application;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Resolver;
using Abstractions.Infrastructure;

namespace Tests.Application
{
    public class TestsApplication
    {
        private IServiceProvider _provider;
        
        [SetUp]
        public void Setup()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddFoodTruck();
            serviceCollection.AddScoped<IConfigureConnection, ConfigureConnectionInMemory>();
            _provider = serviceCollection.BuildServiceProvider();
        }

        [Test]
        public void ArbitraryTest()
        {
            var application = _provider.GetRequiredService<IFoodTruck>();
        }
    }
}