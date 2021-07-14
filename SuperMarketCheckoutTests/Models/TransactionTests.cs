using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SupermarketCheckout.Models;
using SupermarketCheckout.Models.Interfaces;

namespace SuperMarketCheckoutTests.Models
{
    public class TransactionTests
    {
        private static readonly IItem ItemA = new Item("A", 50);
        private static readonly IItem ItemB = new Item("B", 30);
        private static readonly IItem ItemC = new Item("C", 20);
        private static readonly IItem ItemD = new Item("D", 15);

        private static readonly IOffer OfferA = new Offer(ItemA, 3, 130);
        private static readonly IOffer OfferB = new Offer(ItemB, 2, 45);
        private static readonly IOffer OfferC = new Offer(ItemC, 4, 90);
        
        [TestFixture]
        public class FinalTotal{

            private ICurrentItems _currentItems;
            private ICurrentOffers _currentOffers;
            [SetUp]
            public void Setup()
            {
                _currentItems = new CurrentItems();
                var currentOffersDict = new Dictionary<IItem, IOffer>
                {
                    [ItemA] = OfferA, [ItemB] = OfferB
                };
                _currentOffers = new CurrentOffers(currentOffersDict);
                _currentItems.CurrentOffers = _currentOffers;
                _currentItems.Items = new List<IItem> {ItemA, ItemB, ItemC, ItemD};
            }

            [Test]
            public void testOBasketMeetRequirementsOfOffer(){
                var transaction = new Transaction(_currentItems);

                transaction.AddItem(ItemA);
                transaction.AddItem(ItemA);
                transaction.AddItem(ItemA);

                transaction.CalculateFinalTotal();
                Assert.AreEqual(130,transaction.FinalTotal);
            }

            [Test]
            public void Test2(){
                // Given
                var transaction = new Transaction(_currentItems);

                transaction.AddItem(ItemA);
                transaction.AddItem(ItemA);

                var s = transaction.CurrentItems.Items;
                transaction.CalculateFinalTotal();
                Assert.AreEqual(100,transaction.FinalTotal);
            }

            [Test]
            public void Test3(){
                // Given
                var transaction = new Transaction(_currentItems);

                transaction.AddItem(ItemB);
                transaction.AddItem(ItemB);
                transaction.AddItem(ItemB);

                transaction.CalculateFinalTotal();
                Assert.AreEqual(90,transaction.FinalTotal);
            }

        }
    }
}