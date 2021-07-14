using SupermarketCheckout.Models.Interfaces;

namespace SupermarketCheckout.Models
{
    public class Transaction : ITransaction
    {
        public ICurrentItems CurrentItems { get; set; }
        public IBasket Basket { get; set; }
        public long RunningTotal { get; set; }
        public long FinalTotal { get; set; }
        
        public Transaction(ICurrentItems currentOffers){
            Basket = new Basket();
            CurrentItems = currentOffers;
            RunningTotal = 0;
            FinalTotal = 0;
        }
        
        public IBasket AddItem(IItem item)
        {
            Basket.AddToBasket(item);
            RunningTotal += item.UnitPrice;
            RunningTotal += CurrentItems.CurrentOffers.CalculateOfferDiscount(item,Basket);
            return Basket;
        }

        public long CalculateFinalTotal()
        {
            foreach (var item in Basket.GetItemsInBasket())
            {
                FinalTotal += item.UnitPrice * Basket.GetAmountOfItemInBasket(item);
                FinalTotal += CurrentItems.CurrentOffers.CalculateFinalOfferDiscount(item,Basket);
            }
            return FinalTotal;
        }
    }
}