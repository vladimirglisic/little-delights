using LittleDelights.Model.Entities;
using LittleDelights.Model.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LittleDelights.Tests
{
    [TestClass]
    public class SparklingWineTests
    {
        [TestMethod]
        public void CalculatePrice_Wine_Young()
        {
            DateTime now = new DateTime(2022, 6, 1, 12, 0, 0);
            DateTime produced = new DateTime(2022, 6, 1);
            var wine = new Wine(produced, WineType.Sparkling);

            double price = wine.CalculatePrice(now);
            Assert.AreEqual(7, price);
        }

        [TestMethod]
        public void CalculatePrice_Wine_1Day()
        {
            DateTime now = new DateTime(2022, 6, 2, 12, 0, 0);
            DateTime produced = new DateTime(2022, 6, 1);
            var wine = new Wine(produced, WineType.Sparkling);

            double price = wine.CalculatePrice(now);
            Assert.AreEqual(8, price);
        }

        [TestMethod]
        public void CalculatePrice_Wine_2Days()
        {
            DateTime now = new DateTime(2022, 6, 3, 12, 0, 0);
            DateTime produced = new DateTime(2022, 6, 1);
            var wine = new Wine(produced, WineType.Sparkling);

            double price = wine.CalculatePrice(now);
            Assert.AreEqual(9, price);
        }

        [TestMethod]
        public void CalculatePrice_Wine_MaxDay()
        {
            DateTime now = new DateTime(2022, 6, 1, 12, 0, 0).AddDays(293);
            DateTime produced = new DateTime(2022, 6, 1);
            var wine = new Wine(produced, WineType.Sparkling);

            double price = wine.CalculatePrice(now);
            Assert.AreEqual(200, price);
        }

        [TestMethod]
        public void CalculatePrice_Wine_MaxDayPlus()
        {
            DateTime now = new DateTime(2022, 6, 1, 12, 0, 0).AddDays(300);
            DateTime produced = new DateTime(2022, 6, 1);
            var wine = new Wine(produced, WineType.Sparkling);

            double price = wine.CalculatePrice(now);
            Assert.AreEqual(200, price);
        }
    }
}
