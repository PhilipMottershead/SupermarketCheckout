using System.Collections.Concurrent;
using System.Collections.Generic;

namespace SupermarketCheckout.Models.Interfaces
{
    public interface IBasket
    { 
        ConcurrentDictionary<IItem,long> BasketItems { get; set; }
        ICollection<IItem> GetItemsInBasket();
        long GetAmountOfItemInBasket(IItem item);
        void AddToBasket(IItem item);
    }
}