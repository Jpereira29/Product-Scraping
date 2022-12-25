using AutoMapper;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product_Scraping.DTOs;
using Product_Scraping.Models;
using Product_Scraping.Pagination;
using Product_Scraping.Repository;

namespace Product_Scraping.Controllers
{
    [Route("products")]
    [ApiController]
    public class ScrapingController : ControllerBase
    {
        private readonly IUnitOfWork _ofWork;
        private readonly IMapper _mapper;
        public ScrapingController(IUnitOfWork ofWork, IMapper mapper)
        {
            _ofWork = ofWork;
            _mapper = mapper;
        }
        
        [HttpGet("/")]
        public ActionResult TestApi()
        {
            return  Ok("Fullstack Challenge 20201026");
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Product>>> GetAllAsync([FromQuery] ProductsParameters productsParameters)
        {
            var products = await _ofWork.ProductRepository.GetProducts(productsParameters);
            var productsDto = _mapper.Map<List<ProductDTO>>(products);
            return Ok(productsDto);
        }

        [HttpGet("{code:long}")]
        public async Task<ActionResult<Product>> GetByCode(long code)
        {
            var product = await _ofWork.ProductRepository.GetByCode(p => p.Code == code);
            if (product == null)
            {
                return NotFound();
            }
            var productDto = _mapper.Map<ProductDTO>(product);

            return Ok(productDto);
        }
    }
}
