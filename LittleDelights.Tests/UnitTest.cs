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
            //var fish ??
            var wineRed10YearsOld = itemRepository.AddItem(new Wine(tenYearsAgo, WineType.Red));
            var wineRed112DaysOld = itemRepository.AddItem(new Wine(_112DaysAgo, WineType.Red));
            var wineSparkling30DaysOld = itemRepository.AddItem(new Wine(_30DaysAgo, WineType.Sparkling));

            // execute
            var cart = new Cart();
            cart.AddItem(milkFresh, 1);
            cart.AddItem(milk2DaysOverBB, 1);
            //cart.AddItem(fish, 2);
            cart.AddItem(wineRed10YearsOld, 1);
            cart.AddItem(wineRed112DaysOld, 2);
            cart.AddItem(wineSparkling30DaysOld, 1);

            var checkout = new Checkout(itemRepository, now);
            checkout.CreateReceipt(cart);

            // assert

        }
    }
}
