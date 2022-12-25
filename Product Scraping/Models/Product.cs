using Product_Scraping.Enums;
using System.ComponentModel.DataAnnotations;

namespace Product_Scraping.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public long Code { get; set; }

        [Required]
        [MaxLength(30)]
        public string? BarCode { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public DateTime Imported_t { get; set; }

        [Required]
        [MaxLength(400)]
        public string? Url { get; set; }

        [Required]
        [MaxLength(160)]
        public string? Product_name { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Quantity { get; set; }

        [Required]
        [MaxLength(400)]
        public string? Categories { get; set; }

        [Required]
        [MaxLength(400)]
        public string? Packaging { get; set; }

        [Required]
        [MaxLength(400)]
        public string? Brands { get; set; }

        [Required]
        [MaxLength(400)]
        public string? Image_url { get; set; }
    }
}
