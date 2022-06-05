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
    public class MilkTests
    {
        private ItemRepository itemRepository;

        [TestInitialize]
        public void Initialize()
        {
            var dataContext = new Context();
            itemRepository = new ItemRepository(dataContext);
        }

        [TestMethod]
        public void CalculatePrice_Milk_Fresh()
        {
            DateTime now = new DateTime(2022, 5, 28, 12, 0, 0);
            DateTime bestBefore = new DateTime(2022, 6, 1);
            var milk = new Milk(bestBefore);

            double price = milk.CalculatePrice(now);
            Assert.AreEqual(3.7, price);
        }

        [TestMethod]
        public void CalculatePrice_Milk_BestBefore()
        {
            DateTime now = new DateTime(2022, 6, 1, 12, 0, 0);
            DateTime bestBefore = new DateTime(2022, 6, 1);
            var milk = new Milk(bestBefore);

            double price = milk.CalculatePrice(now);
            Assert.AreEqual(3.7, price);
        }

        [TestMethod]
        public void CalculatePrice_Milk_1Day()
        {
            DateTime now = new DateTime(2022, 6, 2, 12, 0, 0);
            DateTime bestBefore = new DateTime(2022, 6, 1);
            var milk = new Milk(bestBefore);

            double price = milk.CalculatePrice(now);
            Assert.AreEqual(1.85, price);
        }

        [TestMethod]
        public void CalculatePrice_Milk_2Days()
        {
            DateTime now = new DateTime(2022, 6, 3, 12, 0, 0);
            DateTime bestBefore = new DateTime(2022, 6, 1);
            var milk = new Milk(bestBefore);

            double price = milk.CalculatePrice(now);
            Assert.AreEqual(1.5725, price);
        }
    }
}
