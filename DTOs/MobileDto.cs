namespace MobilePhoneStore.DTOs
{
    public class MobileDto
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int Stock { get; set; }
        public int BrandId { get; set; }
    }
}
