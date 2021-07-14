using System;
using SupermarketCheckout.Models.Interfaces;

namespace SupermarketCheckout.Models
{
    public class Item : IItem
    {
        public string StockKeepingUnit { get; set; }

        public long UnitPrice { get; set; }

        public Item(string stockKeepingUnit, long unitPrice)
        {
            StockKeepingUnit = stockKeepingUnit;
            UnitPrice = unitPrice;
        }
    }
}