using Product_Scraping.Models;
using Product_Scraping.Pagination;

namespace Product_Scraping.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProducts(ProductsParameters productsParameters);
        Task DeleteAllDataTable();
    }
}
