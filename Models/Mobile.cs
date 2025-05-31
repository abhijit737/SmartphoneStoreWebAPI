using System.ComponentModel.DataAnnotations;

namespace MobilePhoneStore.Models
{
    public class Mobile
    {
        [Required]

        public int Id { get; set; }
        public string ModelName { get; set; }
        [Required]
        public decimal CostPrice { get; set; }
        [Required]
        public decimal SellingPrice { get; set; }
        public int Stock { get; set; }

        [Required]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
