using System;
using NUnit.Framework;
using SupermarketCheckout.Models;
using SupermarketCheckout.Models.Interfaces;

namespace SuperMarketCheckoutTests.Models
{
    public class ItemsTest
    {
          private IItem _item;

          [SetUp]
          public void Setup()
          {
              _item = new Item("A",50);
          }

          [Test]
          public void TestSetSku()
          {
              Assert.AreEqual("A",_item.StockKeepingUnit);
          }
    }
}