using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestTaskIronWaterStudio.Models;

namespace TestTaskIronWaterStudio.Controllers.Api
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (!_productRepository.AllProducts.Any(p => p.ProductId == id))
                return NotFound();

            return new JsonResult(_productRepository.AllProducts.Where(p => p.ProductId == id));
        }

        [HttpGet]
        public IActionResult GetAll(string? name, decimal? minPrice, decimal? maxPrice)
        {
            IEnumerable<Product> filteredProducts = _productRepository.AllProducts;

            if (!string.IsNullOrEmpty(name))
            {
                filteredProducts = filteredProducts.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            }

            if (minPrice.HasValue)
            {
                filteredProducts = filteredProducts.Where(p => p.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                filteredProducts = filteredProducts.Where(p => p.Price <= maxPrice.Value);
            }

            var result = filteredProducts
                .Select(p => new { p.ProductId, p.Name, p.Price })
                .OrderBy(p => p.ProductId);

            return new JsonResult(result);
        }
    }
}
