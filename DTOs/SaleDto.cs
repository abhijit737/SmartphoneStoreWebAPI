namespace MobilePhoneStore.DTOs
{
    public class SaleDto
    {
        public int CustomerId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal Discount { get; set; }
        public List<SaleItemDto> Items { get; set; }
    }
}
