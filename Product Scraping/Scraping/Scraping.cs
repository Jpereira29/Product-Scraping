using HtmlAgilityPack;
using Product_Scraping.Models;
using Product_Scraping.Repository;

public class Scraping {

    private static IUnitOfWork? _ofWork;

    public Scraping(IUnitOfWork ofWork)
    {
        _ofWork = ofWork;
    }
    public Scraping()
    {
    }

    public async Task GetScrapingResult()
    {
        Console.WriteLine("started");

        //remove all data table for update
        await _ofWork.ProductRepository.DeleteAllDataTable();

        HttpClient hc = new HttpClient();
        HttpResponseMessage result = await hc.GetAsync($"https://world.openfoodfacts.org");
        Stream stream = await result.Content.ReadAsStreamAsync();
        HtmlDocument doc = new HtmlDocument();
        doc.Load(stream);
        var HeaderProductsLinks = doc.DocumentNode.SelectSingleNode("//*[@id=\"search_results\"]")
            .Descendants("a")
            .Select(a => a.Attributes["href"].Value)
            .ToList();

        foreach (var productLink in HeaderProductsLinks)
        {
            try
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument document = web.Load($"https://world.openfoodfacts.org{productLink}");

                var title = document.DocumentNode.SelectSingleNode("//*[@id=\"prodHead\"]/div/div/h1").InnerText;

                var barCode = document.DocumentNode.SelectSingleNode("//*[@id=\"barcode_paragraph\"]")
                    .InnerText.Trim().Split(':');

                var code = barCode[1].Split('(');


                var quantity = document.DocumentNode.SelectSingleNode("//*[@id=\"field_quantity_value\"]")
                .InnerText;

                var url = "https://world.openfoodfacts.org" + productLink;

                var categories = document.DocumentNode.SelectSingleNode("//*[@id=\"field_categories_value\"]").InnerText;

                var packaging = document.DocumentNode.SelectSingleNode("//*[@id=\"field_packaging_value\"]").InnerText;

                var imageUrl = document.DocumentNode.SelectSingleNode("//*[@id=\"og_image\"]")
                    .Attributes["src"].Value;

                var brands = document.DocumentNode.SelectSingleNode("//*[@id=\"field_brands_value\"]").InnerText;

                var date = DateTimeOffset.Now;

                Product product = new Product
                {
                    Product_name = title,
                    BarCode = barCode[1],
                    Code = long.Parse(code[0]),
                    Quantity = quantity,
                    Url = url,
                    Status = Product_Scraping.Enums.Status.Imported,
                    Categories = categories,
                    Packaging = packaging,
                    Brands = brands,
                    Image_url = imageUrl,
                    Imported_t = DateTime.Parse(date.ToString()),
                };

                _ofWork.ProductRepository.Add(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //remove all data table for update
        await _ofWork.ProductRepository.DeleteAllDataTable();
        await _ofWork.Commit();
    }
}