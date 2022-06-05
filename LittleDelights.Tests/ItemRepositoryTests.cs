using LittleDelights.Contract.Interfaces;
using LittleDelights.Data;
using LittleDelights.Data.Repositories;
using LittleDelights.Model.Entities;
using LittleDelights.Model.Enums;
using LittleDelights.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace LittleDelights.Tests
{
    [TestClass]
    public class ItemRepositoryTests
    {
        private ItemRepository itemRepository;

        [TestInitialize]
        public void Initialize()
        {
            var dataContext = new Context();
            itemRepository = new ItemRepository(dataContext);
        }

        [TestMethod]
        public void AddItem_Roundtrip()
        {
            // prepare
            DateTime now = new DateTime(2022, 6, 1);

            // execute
            var milkId = itemRepository.AddItem(new Milk(now));
            var milk = itemRepository.GetItem(milkId);

            // assert
            Assert.AreEqual("Milk", milk.Name, "Milk is found in repository");
        }

        [TestMethod]
        public void GetItem_ItemNotFound()
        {
            // prepare
            DateTime now = new DateTime(2022, 6, 1);
            itemRepository.AddItem(new Milk(now));

            // execute
            var itemNotFound = itemRepository.GetItem(Guid.NewGuid());

            // assert
            Assert.IsNull(itemNotFound, "Item not found in repository");
        }

        [TestMethod]
        public void AddItem_GetItems()
        {
            // prepare
            DateTime now = new DateTime(2022, 6, 1);
            itemRepository.AddItem(new Milk(now));
            itemRepository.AddItem(new Fish(now));

            // execute
            var items = itemRepository.GetItems();

            // assert
            Assert.IsTrue(items.Values.Any(x => x.Name == "Milk"), "Milk is found in repository");
            Assert.IsTrue(items.Values.Any(x => x.Name == "Fish"), "Fish is found in repository");
        }
    }
}
