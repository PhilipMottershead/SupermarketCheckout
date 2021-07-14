using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SupermarketCheckout.Models;
using SupermarketCheckout.Models.Interfaces;

namespace SuperMarketCheckoutTests.Models
{
    public class OfferTests
    {
        private static readonly IItem ItemA = new Item("A", 50);
        private static readonly IItem ItemB = new Item("B", 30);

        private IOffer _offer;

        [SetUp]
        public void Setup(){
            _offer =  new Offer(ItemA,3,130);
        }

        [Test]
        public void TestCalculateDiscount()
        {
            Assert.AreEqual(-20, _offer.Discount);
        }

        [Test]
        public void TestCalculateDiscount2(){
            _offer.UpdateRequiredAmount(4);
            Assert.AreEqual(-70,_offer.Discount);
        }

        [Test]
        public void TestCalculateDiscount3(){
            _offer.UpdateRequiredAmount(2);
            Assert.AreEqual(0,_offer.Discount);
        }

        [Test]
        public void TestCalculateDiscount4(){
            _offer.UpdateTotalCost(100);
            Assert.AreEqual(-50,_offer.Discount);
        }

        [Test]
        public void TestCalculateDiscount5(){
            _offer.UpdateRequiredAmount(4);
            _offer.UpdateTotalCost(100);
            _offer.UpdateItem(ItemB);

            Assert.AreEqual(-20,_offer.Discount);
        }
    }
}