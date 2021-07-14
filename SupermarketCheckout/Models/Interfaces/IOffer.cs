namespace SupermarketCheckout.Models.Interfaces
{
    public interface IOffer
    {
        public IItem Item { get; set; }
        public long RequiredAmount { get; set; }
        public long TotalCost { get; set; }
        public long Discount { get; set; }
        public void UpdateRequiredAmount(long requiredAmount);
        public void UpdateTotalCost(long totalCost);
        public void UpdateItem(IItem item);

    }
}