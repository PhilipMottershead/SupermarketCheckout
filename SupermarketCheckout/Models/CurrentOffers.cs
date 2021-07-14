using System.Collections.Generic;
using SupermarketCheckout.Models.Interfaces;

namespace SupermarketCheckout.Models
{
    public class CurrentOffers : ICurrentOffers
    {
        public CurrentOffers(IDictionary<IItem, IOffer> currentOffers) {
            CurrentOffersDict = currentOffers;
        }

        public IDictionary<IItem, IOffer> CurrentOffersDict { get; set; }
      
        public bool HasOffer(IItem item)
        {
            return CurrentOffersDict.ContainsKey(item);
        }

        public long CalculateOfferDiscount(IItem item, IBasket basket)
        {
            return CalculateOffer(item, false, basket);
        }

        public long CalculateFinalOfferDiscount(IItem item, IBasket basket)
        {
            return CalculateOffer(item, true, basket);
        }

        public long CalculateOffer(IItem item,bool isFinalCheck,IBasket basket){
            if (!HasOffer(item)) return 0;
            
            var offer = CurrentOffersDict[item];
            var amount = basket.GetAmountOfItemInBasket(item);
            var requiredAmount = offer.RequiredAmount;

            if (!isFinalCheck) return offer.Discount;
            if (amount % requiredAmount != 0) return 0;
            return offer.Discount * amount / requiredAmount;

        }
    }
}