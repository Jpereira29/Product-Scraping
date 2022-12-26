using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Product_Scraping.DTOs;
using Product_Scraping.Pagination;
using Product_Scraping.Repository;

namespace Product_Scraping.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _ofWork;
        private readonly IMapper _mapper;
        public ProductsController(IUnitOfWork ofWork, IMapper mapper)
        {
            _ofWork = ofWork;
            _mapper = mapper;
        }
        
        [HttpGet("/")]
        public ActionResult<string> TestApi()
        {
            return  Ok("Fullstack Challenge 20201026");
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ProductDTO>>> GetAllAsync([FromQuery] ProductsParameters productsParameters)
        {
            try
            {
                var products = await _ofWork.ProductRepository.GetProducts(productsParameters);
                var productsDto = _mapper.Map<List<ProductDTO>>(products);

                return productsDto;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{code:long}")]
        public async Task<ActionResult<ProductDTO>> GetByCodeAsync(long code)
        {
            try
            {
                var product = await _ofWork.ProductRepository.GetByCode(p => p.Code == code);
                if (product == null)
                {
                    return NotFound();
                }
                var productDto = _mapper.Map<ProductDTO>(product);

                return productDto;
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
