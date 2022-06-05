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
    public class FishTests
    {
        private ItemRepository itemRepository;

        [TestInitialize]
        public void Initialize()
        {
            var dataContext = new Context();
            itemRepository = new ItemRepository(dataContext);
        }

        [TestMethod]
        public void CalculatePrice_Fish_Fresh()
        {
            DateTime now = new DateTime(2022, 6, 1, 12, 0, 0);
            DateTime captured = new DateTime(2022, 6, 1);
            var fish = new Fish(captured);

            double price = fish.CalculatePrice(now);
            Assert.AreEqual(5, price);
        }

        [TestMethod]
        public void CalculatePrice_Fish_1Day()
        {
            DateTime now = new DateTime(2022, 6, 2, 12, 0, 0);
            DateTime captured = new DateTime(2022, 6, 1);
            var fish = new Fish(captured);

            double price = fish.CalculatePrice(now);
            Assert.AreEqual(4.5, price);
        }

        [TestMethod]
        public void CalculatePrice_Fish_2Days()
        {
            DateTime now = new DateTime(2022, 6, 3, 12, 0, 0);
            DateTime captured = new DateTime(2022, 6, 1);
            var fish = new Fish(captured);

            double price = fish.CalculatePrice(now);
            Assert.AreEqual(4.05, price);
        }
    }
}
