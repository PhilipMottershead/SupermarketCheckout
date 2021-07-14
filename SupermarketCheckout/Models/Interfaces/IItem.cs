namespace SupermarketCheckout.Models.Interfaces
{
    public interface IItem
    {
        string StockKeepingUnit { get; set; }
        long UnitPrice { get; set; }
    }
}