namespace MobilePhoneStore.DTOs
{
    public class SaleItemDto
    {
        public int MobileId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountApplied { get; set; }
    }
}
