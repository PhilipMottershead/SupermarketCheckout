using System.Collections.Concurrent;
using NUnit.Framework;
using SupermarketCheckout.Models;
using SupermarketCheckout.Models.Interfaces;

namespace SuperMarketCheckoutTests.Models
{
    public class BasketTests
    {
        private static readonly IItem ItemA = new Item("A", 50);
        private static readonly IItem ItemB = new Item("B", 30);
        private static readonly IItem ItemC = new Item("C", 20);
        private static readonly IItem ItemD = new Item("B", 15);

        private Basket _basket;
        
        [SetUp]
        public void Setup()
        {
            _basket = new Basket();
        }
        
        [Test]
        public void TestBasketInitialisedOnCreation(){
            Assert.AreEqual(_basket.BasketItems,new ConcurrentDictionary<IItem,ulong>());
        }
        
        [Test]
        public void TestAlreadyExistedItemAreIncremented()
        {
            var mapBasket = new ConcurrentDictionary<IItem, long> {[ItemA] = 1};
            _basket.BasketItems = mapBasket;
            _basket.AddToBasket(ItemA);
            mapBasket[ItemA] = 2;

            Assert.AreEqual(_basket.BasketItems, mapBasket);
        }

        [Test]
        public void TestNewItemIsAdded()
        {
            var mapBasket = new ConcurrentDictionary<IItem, long> {[ItemA] = 1};
            _basket.BasketItems = mapBasket;
            Assert.AreEqual(_basket.BasketItems, mapBasket);
        }
        
        [Test]
        public void TestGetItemInBasket()
        {
            IBasket basket = new Basket();
            var mapBasket = new ConcurrentDictionary<IItem, long> {[ItemA] = 1,[ItemB] = 1};
            basket.BasketItems = mapBasket;
            _basket.AddToBasket(ItemA);
            _basket.AddToBasket(ItemB);
            
            Assert.AreEqual(basket.BasketItems,_basket.BasketItems);
        }

        [Test]
        public void TestGetAmountOfItemInBasket()
        {
            _basket.AddToBasket(ItemA);
            Assert.AreEqual(1,_basket.GetAmountOfItemInBasket(ItemA));
        }
        
        [Test]
        public void TestGetAmountOfItemInBasketIncremented()
        {
            _basket.AddToBasket(ItemA);
            _basket.AddToBasket(ItemA);
            Assert.AreEqual(2,_basket.GetAmountOfItemInBasket(ItemA));
        }
        
        [Test]
        public void TestGetAmountOfItemInBasketMultipleItems()
        {
            _basket.AddToBasket(ItemA);
            _basket.AddToBasket(ItemB);
            _basket.AddToBasket(ItemA);
            Assert.AreEqual(2,_basket.GetAmountOfItemInBasket(ItemA));
            Assert.AreEqual(1,_basket.GetAmountOfItemInBasket(ItemB));

        }

    }
}