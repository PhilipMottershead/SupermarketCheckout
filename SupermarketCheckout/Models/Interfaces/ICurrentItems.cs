using System.Collections.Generic;

namespace SupermarketCheckout.Models.Interfaces
{
    public interface ICurrentItems
    {
        public List<IItem> Items { get; set; }
        public ICurrentOffers CurrentOffers { get; set; }
    }
}