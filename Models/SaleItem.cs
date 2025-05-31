using System.ComponentModel.DataAnnotations;

namespace MobilePhoneStore.Models
{
    public class SaleItem
    {
        public int Id { get; set; }
        [Required]
        public int SaleId { get; set; }
        public Sale Sale { get; set; }

        [Required]
        public int MobileId { get; set; }
        public Mobile Mobile { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        public decimal DiscountApplied { get; set; }
    }
}
