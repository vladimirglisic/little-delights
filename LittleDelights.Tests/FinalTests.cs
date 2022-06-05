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
    public class FinalTests
    {
        private ItemRepository itemRepository;

        [TestInitialize]
        public void Initialize()
        {
            var dataContext = new Context();
            itemRepository = new ItemRepository(dataContext);
        }

        [TestMethod]
        public void Final()
        {
            // prepare
            DateTime now = new DateTime(2022, 6, 1);
            DateTime twoDaysAgo = now.AddDays(-2);
            DateTime tenYearsAgo = now.AddYears(-10);
            DateTime _112DaysAgo = now.AddDays(-112);
            DateTime _30DaysAgo = now.AddDays(-30);

            var milkFresh = itemRepository.AddItem(new Milk(now));
            var milk2DaysOverBB = itemRepository.AddItem(new Milk(twoDaysAgo));
            var fish2DaysOverCaptured = itemRepository.AddItem(new Fish(twoDaysAgo));
            var wineRed10YearsOld = itemRepository.AddItem(new Wine(tenYearsAgo, WineType.Red));
            var wineRed112DaysOld = itemRepository.AddItem(new Wine(_112DaysAgo, WineType.Red));
            var wineSparkling30DaysOld = itemRepository.AddItem(new Wine(_30DaysAgo, WineType.Sparkling));

            // execute
            var cart = new Cart();
            cart.AddItem(milkFresh, 1);
            cart.AddItem(milk2DaysOverBB, 1);
            cart.AddItem(fish2DaysOverCaptured, 2);
            cart.AddItem(wineRed10YearsOld, 1);
            cart.AddItem(wineRed112DaysOld, 2);
            cart.AddItem(wineSparkling30DaysOld, 1);

            var checkout = new Checkout(itemRepository, now);
            checkout.CreateReceipt(cart);

            // assert
            Assert.AreEqual(3.7, checkout.Receipt[0].Price, "1x Milk (fresh)");
            Assert.AreEqual(1.57, checkout.Receipt[1].Price, .5, "1x Milk (2 days)");
            Assert.AreEqual(8.1, checkout.Receipt[2].Price, "2x Fish (2 days)");
            Assert.AreEqual(200, checkout.Receipt[3].Price, "1x Red Wine (10 years)");
            Assert.AreEqual(234, checkout.Receipt[4].Price, "2x Red Wine (112 days)");
            Assert.AreEqual(37, checkout.Receipt[5].Price, "1x Red Wind (30 days)");
            Assert.AreEqual(484.37, checkout.Receipt[6].Price, .5, "Total");
        }
    }
}
