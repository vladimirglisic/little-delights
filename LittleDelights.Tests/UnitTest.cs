using LittleDelights.Contract.Interfaces;
using LittleDelights.Model.Entities;
using LittleDelights.Model.Enums;
using LittleDelights.Model.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LittleDelights.Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Final()
        {
            DateTime now = new DateTime(2022, 6, 1);
            DateTime twoDaysAgo = now.AddDays(-2);
            DateTime tenYearsAgo = now.AddYears(-10);
            DateTime _112DaysAgo = now.AddDays(-112);
            DateTime _30DaysAgo = now.AddDays(-30);

            var milkFresh = new Milk(now);
            var milk2DaysOverBB = new Milk(twoDaysAgo);
            //var fish ??
            var wineRed10YearsOld = new Wine(tenYearsAgo, WineType.Red);
            var wineRed112DaysOld = new Wine(_112DaysAgo, WineType.Red);
            var wineSparkling30DaysOld = new Wine(_30DaysAgo, WineType.Sparkling);

            ICart cart = new Cart();
            cart.AddItem(milkFresh.Id, 1);
            cart.AddItem(milk2DaysOverBB.Id, 1);
            //cart.AddItem(fish, 2);
            cart.AddItem(wineRed10YearsOld.Id, 1);
            cart.AddItem(wineRed112DaysOld.Id, 2);
            cart.AddItem(wineSparkling30DaysOld.Id, 1);

            ICheckout checkout = new Checkout(now);
            checkout.CreateReceipt(cart);
        }
    }
}
