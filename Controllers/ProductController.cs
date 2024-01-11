using Microsoft.AspNetCore.Mvc;
using TestTaskIronWaterStudio.Models;
using TestTaskIronWaterStudio.ViewModels;

namespace TestTaskIronWaterStudio.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult List()
        {
            IEnumerable<Product> products;

            products = _productRepository.AllProducts.OrderBy(p => p.ProductId);

            var productListViewModel = new ProductListViewModel(products);

            return View(productListViewModel);
        }
    }
}
