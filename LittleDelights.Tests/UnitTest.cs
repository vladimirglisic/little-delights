using LittleDelights.Contract.Interfaces;
using LittleDelights.Data;
using LittleDelights.Data.Repositories;
using LittleDelights.Model.Entities;
using LittleDelights.Model.Enums;
using LittleDelights.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LittleDelights.Tests
{
    [TestClass]
    public class UnitTest
    {
        private readonly ItemRepository itemRepository;
        private readonly ICart cart;
        private readonly ICheckout checkout;
        private readonly DateTime now;

        public UnitTest()
        {
            now = new DateTime(2022, 6, 1);

            var services = new ServiceCollection();

            services.AddSingleton<Context>();
            services.AddScoped<ItemRepository>();
            services.AddScoped<ICart, Cart>();
            services.AddScoped<ICheckout>(x =>
                new Checkout(
                    x.GetRequiredService<ItemRepository>(),
                    now
                )
            );

            var serviceProvider = services.BuildServiceProvider();

            itemRepository = serviceProvider.GetService<ItemRepository>();
            cart = serviceProvider.GetService<ICart>();
            checkout = serviceProvider.GetService<ICheckout>();
        }

        [TestMethod]
        public void Final()
        {
            // prepare
            DateTime twoDaysAgo = now.AddDays(-2);
            DateTime tenYearsAgo = now.AddYears(-10);
            DateTime _112DaysAgo = now.AddDays(-112);
            DateTime _30DaysAgo = now.AddDays(-30);

            var milkFresh = itemRepository.AddItem(new Milk(now));
            var milk2DaysOverBB = itemRepository.AddItem(new Milk(twoDaysAgo));
            //var fish ??
            var wineRed10YearsOld = itemRepository.AddItem(new Wine(tenYearsAgo, WineType.Red));
            var wineRed112DaysOld = itemRepository.AddItem(new Wine(_112DaysAgo, WineType.Red));
            var wineSparkling30DaysOld = itemRepository.AddItem(new Wine(_30DaysAgo, WineType.Sparkling));

            // execute
            cart.AddItem(milkFresh, 1);
            cart.AddItem(milk2DaysOverBB, 1);
            //cart.AddItem(fish, 2);
            cart.AddItem(wineRed10YearsOld, 1);
            cart.AddItem(wineRed112DaysOld, 2);
            cart.AddItem(wineSparkling30DaysOld, 1);

            checkout.CreateReceipt(cart);

            // assert

        }
    }
}
