namespace SupermarketCheckout.Models.Interfaces
{
    public interface ITransaction
    {
        ICurrentOffers CurrentOffers { get; set; }
        IBasket Basket { get; set; }
        long RunningTotal { get; set; }
        long FinalTotal{ get; set; }
        IBasket AddItem(IItem item);
        long CalculateFinalTotal();
    }
}