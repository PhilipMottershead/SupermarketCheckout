using System.Collections.Generic;

namespace SupermarketCheckout.Models.Interfaces
{
    public interface ICurrentOffers
    {
        IDictionary<IItem, IOffer> CurrentOffersDict { get; set; }
        bool HasOffer(IItem item);
        long CalculateOfferDiscount(IItem item,IBasket basket);
        long CalculateFinalOfferDiscount(IItem item,IBasket basket);
        long CalculateOffer(IItem item,bool isFinalCheck,IBasket basket);
    }
}