using TestTaskIronWaterStudio.Models;

namespace TestTaskIronWaterStudio.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public ProductListViewModel(IEnumerable<Product> products)
        {
            Products = products;
        }
    }
}
