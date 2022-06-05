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
    public class CheckoutTests
    {
        private ItemRepository itemRepository;

        [TestInitialize]
        public void Initialize()
        {
            var dataContext = new Context();
            itemRepository = new ItemRepository(dataContext);
        }

        [TestMethod]
        public void CreateReceipt()
        {
            // prepare
            DateTime now = new DateTime(2022, 6, 1);
            DateTime twoDaysAgo = now.AddDays(-2);

            var milkFresh = itemRepository.AddItem(new Milk(now));
            var fish2DaysOverCaptured = itemRepository.AddItem(new Fish(twoDaysAgo));

            // execute
            var cart = new Cart();
            cart.AddItem(milkFresh, 1);
            cart.AddItem(fish2DaysOverCaptured, 2);

            var checkout = new Checkout(itemRepository, now);
            checkout.CreateReceipt(cart);
            string receiptText = checkout.ToString();
            string[] receiptLines = receiptText.Split(Environment.NewLine);

            // assert
            Assert.AreEqual("          Little Delights Shop", receiptLines[0]);
            Assert.AreEqual("==================================================", receiptLines[1]);
            Assert.AreEqual("Milk                                         $3.70", receiptLines[2]);
            Assert.AreEqual("Fish                                         $8.10", receiptLines[3]);
            Assert.AreEqual("--------------------------------------------------", receiptLines[4]);
            Assert.AreEqual("Total                                       $11.80", receiptLines[5]);
        }
    }
}
