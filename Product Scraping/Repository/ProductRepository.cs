using Hangfire.MemoryStorage.Database;
using Microsoft.EntityFrameworkCore;
using Product_Scraping.Context;
using Product_Scraping.Models;
using Product_Scraping.Pagination;

namespace Product_Scraping.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task DeleteAllDataTable()
        {
            await _context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Products");
        }

        public async Task<IEnumerable<Product>> GetProducts(ProductsParameters productsParameters)
        {
            return await Get()
                .Skip((productsParameters.PageNumber -1) * productsParameters.PageSize)
                .Take(productsParameters.PageSize)
                .ToListAsync();
        }
    }
}
