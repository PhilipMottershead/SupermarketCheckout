using System.Collections.Concurrent;
using System.Collections.Generic;
using NUnit.Framework;
using SupermarketCheckout.Models;
using SupermarketCheckout.Models.Interfaces;

namespace SuperMarketCheckoutTests.Models
{
    public class CurrentOffersTests
    {
         private static readonly IItem ItemA = new Item("A", 50);
         private static readonly IItem ItemB = new Item("B", 30);
         private static readonly IItem ItemC = new Item("C", 20);
        
         private static readonly IOffer OfferA = new Offer(ItemA, 3, 130);
         private static readonly IOffer OfferB = new Offer(ItemB, 2, 45);
         private static readonly IOffer OfferC = new Offer(ItemC, 4, 90);
        
         private static IDictionary<IItem, IOffer> _currentOffersMap;
        
                
        
         [TestFixture]
         public class TestHasOffer
         {
                    
             [SetUp]
             public void Setup()
             {
                 var currentOffersMap = new Dictionary<IItem, IOffer>
                        {
                            [ItemA] = OfferA, [ItemB] = OfferB
                        };
                        _currentOffersMap = currentOffersMap;
                    }
                    [Test]
                    public void TestItemWithOffer()
                    {
                        ICurrentOffers currentOffers = new CurrentOffers(_currentOffersMap);
                        Assert.True(currentOffers.HasOffer(ItemA));
                    }
        
                    [Test]
                    public void TestItemWithoutOffer(){
                        ICurrentOffers currentOffers = new CurrentOffers(_currentOffersMap);
                        Assert.False(currentOffers.HasOffer(ItemC));            }
                }
        
              
                
        
                [TestFixture]
                public class TestCalculateOffer {
        
                    private static IBasket _basket;
        
                    [SetUp]
                    public void Setup(){
                        _basket = new Basket();
                        var basketMap = new ConcurrentDictionary<IItem, long>()
                        {
                            [ItemA] = 2, [ItemB] = 3, [ItemC] = 4
                        };
                        
                        var currentOffersMap = new Dictionary<IItem, IOffer>
                        {
                            [ItemA] = OfferA, [ItemB] = OfferB,[ItemC] = OfferC
                        };
                        _currentOffersMap = currentOffersMap;
                        _basket.BasketItems = basketMap;
                    }
        
                    [Test]
                    public void TestItemHasOffer(){
                        ICurrentOffers currentOffers = new CurrentOffers(_currentOffersMap);
        
                        var offer = currentOffers.CalculateOfferDiscount(ItemA,_basket);
                        Assert.AreEqual(-20,offer);
                    }
        
                    [Test]
                    public void TestNegativeDiscount()
                    {
                        ICurrentOffers currentOffers = new CurrentOffers(_currentOffersMap);
                        var offer = currentOffers.CalculateOfferDiscount(ItemC,_basket);
                        Assert.AreEqual(0,offer);
        
                    }
        
                    [Test]
                    public void TestItemHasNoOffer(){
                        ICurrentOffers currentOffers = new CurrentOffers(_currentOffersMap);
        
                        var offer = currentOffers.CalculateOfferDiscount(ItemC,_basket);
                        Assert.AreEqual(0,offer);
                    }
                }
    }
}