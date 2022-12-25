namespace Product_Scraping.Repository
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        Task Commit();
    }
}
