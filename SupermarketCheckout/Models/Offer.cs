using SupermarketCheckout.Models.Interfaces;

namespace SupermarketCheckout.Models
{
    public class Offer : IOffer
    {
        public IItem Item { get; set; }
        public long RequiredAmount { get; set; }
        public long TotalCost { get; set; }
        public long Discount { get; set; }
        
        public Offer(IItem item, long requiredAmount, long totalCost) {
            Item = item;
            RequiredAmount = requiredAmount;
            TotalCost = totalCost;
            CalculateDiscount();
        }
        
        private void CalculateDiscount(){
            Discount = TotalCost - (Item.UnitPrice * RequiredAmount);
            if(Discount > 0){
                Discount = 0;
            }
        }
    }
}