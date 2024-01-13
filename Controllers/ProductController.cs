using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTaskIronWaterStudio.Models;
using TestTaskIronWaterStudio.ViewModels;

namespace TestTaskIronWaterStudio.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products;

            products = _productRepository.AllProducts.OrderBy(p => p.ProductId);

            var productListViewModel = new ProductListViewModel(products);

            return View(productListViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Description,Price")] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productRepository.AddProduct(product);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(product);
        }

        public IActionResult Edit(int productId)
        {
            var product = _productRepository.GetProductById(productId);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int productId, [Bind("ProductId,Name,Description,Price")] Product product)
        {
            if (productId != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _productRepository.UpdateProduct(product);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }

            return View(product);
        }
    }
}
