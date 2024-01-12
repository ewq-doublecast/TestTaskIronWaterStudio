namespace TestTaskIronWaterStudio.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly TestTaskDbContext _dbContext;

        public ProductRepository(TestTaskDbContext testTaskDbContext)
        {
            _dbContext = testTaskDbContext;
        }

        public IEnumerable<Product> AllProducts
        {
            get
            {
                return _dbContext.Products.OrderBy(p => p.Name);
            }
        }

        public Product? GetProductById(int productId)
        {
            return _dbContext.Products.FirstOrDefault(p => p.ProductId == productId);
        }

        public void AddProduct(Product product)
        {
            _dbContext.Add(product);
            _dbContext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _dbContext.Update(product);
            _dbContext.SaveChanges();
        }
    }
}
