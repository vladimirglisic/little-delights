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
    public class RedWineTests
    {
        [TestMethod]
        public void CalculatePrice_Wine_Young()
        {
            DateTime now = new DateTime(2022, 6, 1, 12, 0, 0);
            DateTime produced = new DateTime(2022, 6, 1);
            var wine = new Wine(produced, WineType.Red);

            double price = wine.CalculatePrice(now);
            Assert.AreEqual(5, price);
        }

        [TestMethod]
        public void CalculatePrice_Wine_1Day()
        {
            DateTime now = new DateTime(2022, 6, 2, 12, 0, 0);
            DateTime produced = new DateTime(2022, 6, 1);
            var wine = new Wine(produced, WineType.Red);

            double price = wine.CalculatePrice(now);
            Assert.AreEqual(6, price);
        }

        [TestMethod]
        public void CalculatePrice_Wine_2Days()
        {
            DateTime now = new DateTime(2022, 6, 3, 12, 0, 0);
            DateTime produced = new DateTime(2022, 6, 1);
            var wine = new Wine(produced, WineType.Red);

            double price = wine.CalculatePrice(now);
            Assert.AreEqual(7, price);
        }

        [TestMethod]
        public void CalculatePrice_Wine_MaxDay()
        {
            DateTime now = new DateTime(2022, 6, 1, 12, 0, 0).AddDays(295);
            DateTime produced = new DateTime(2022, 6, 1);
            var wine = new Wine(produced, WineType.Red);

            double price = wine.CalculatePrice(now);
            Assert.AreEqual(200, price);
        }

        [TestMethod]
        public void CalculatePrice_Wine_MaxDayPlus()
        {
            DateTime now = new DateTime(2022, 6, 1, 12, 0, 0).AddDays(300);
            DateTime produced = new DateTime(2022, 6, 1);
            var wine = new Wine(produced, WineType.Red);

            double price = wine.CalculatePrice(now);
            Assert.AreEqual(200, price);
        }
    }
}
