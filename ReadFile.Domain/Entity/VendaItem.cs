namespace ReadFile.Domain.Entity
{
    public class VendaItem
    {
        public VendaItem(int itemId, int itemQuantity, decimal itemPrice)
        {
            ItemId = itemId;
            ItemQuantity = itemQuantity;
            ItemPrice = itemPrice;
        }

        public int ItemId { get; }
        public int ItemQuantity { get; }
        public decimal ItemPrice { get; }
    }
}
