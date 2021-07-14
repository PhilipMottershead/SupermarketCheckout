using System.Collections.Generic;
using SupermarketCheckout.Models.Interfaces;

namespace SupermarketCheckout.Models
{
    public class CurrentItems : ICurrentItems
    {
        public List<IItem> Items { get; set; }
        public ICurrentOffers CurrentOffers { get; set; }
    }
}