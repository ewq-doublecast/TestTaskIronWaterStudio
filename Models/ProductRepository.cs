namespace TestTaskIronWaterStudio.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly TestTaskDbContext _testTaskDbContext;

        public ProductRepository(TestTaskDbContext testTaskDbContext)
        {
            _testTaskDbContext = testTaskDbContext;
        }

        public IEnumerable<Product> AllProducts
        {
            get
            {
                return _testTaskDbContext.Products.OrderBy(p => p.Name);
            }
        }

        public Product? GetProductById(int productId)
        {
            return _testTaskDbContext.Products.FirstOrDefault(p => p.ProductId == productId);
        }
    }
}
