using Product_Scraping.Enums;

namespace Product_Scraping.DTOs
{
    public class ProductDTO
    {
        public long Code { get; set; }
        public string? BarCode { get; set; }
        public Status Status { get; set; }
        public DateTime Imported_t { get; set; }
        public string? Url { get; set; }
        public string? Product_name { get; set; }
        public string? Quantity { get; set; }
        public string? Categories { get; set; }
        public string? Packaging { get; set; }
        public string? Brands { get; set; }
        public string? Image_url { get; set; }
    }
}
