using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using SupermarketCheckout.Models.Interfaces;

namespace SupermarketCheckout.Models
{
    public class Basket : IBasket
    {
        public ConcurrentDictionary<IItem, long> BasketItems { get; set; }

        public Basket()
        {
            BasketItems = new ConcurrentDictionary<IItem, long>();
        }
        
        public ICollection<IItem> GetItemsInBasket()
        {
            return BasketItems.Keys;
        }

        public long GetAmountOfItemInBasket(IItem item)
        {
            return BasketItems[item];
        }

        public void AddToBasket(IItem item)
        {
            BasketItems.AddOrUpdate(item, 1, (id, count) => count + 1);
        }
    }
}