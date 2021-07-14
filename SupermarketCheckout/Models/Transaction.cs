using SupermarketCheckout.Models.Interfaces;

namespace SupermarketCheckout.Models
{
    public class Transaction : ITransaction
    {
        public ICurrentOffers CurrentOffers { get; set; }
        public IBasket Basket { get; set; }
        public long RunningTotal { get; set; }
        public long FinalTotal { get; set; }
        
        public Transaction(ICurrentOffers currentOffers){
            Basket = new Basket();
            CurrentOffers = currentOffers;
            RunningTotal = 0;
            FinalTotal = 0;
        }
        
        public IBasket AddItem(IItem item)
        {
            Basket.AddToBasket(item);
            RunningTotal += item.UnitPrice;
            RunningTotal += CurrentOffers.CalculateOfferDiscount(item,Basket);
            return Basket;
        }

        public long CalculateFinalTotal()
        {
            foreach (var item in Basket.GetItemsInBasket())
            {
                FinalTotal += item.UnitPrice * Basket.GetAmountOfItemInBasket(item);
                FinalTotal += CurrentOffers.CalculateFinalOfferDiscount(item,Basket);
            }
            return FinalTotal;
        }
    }
}