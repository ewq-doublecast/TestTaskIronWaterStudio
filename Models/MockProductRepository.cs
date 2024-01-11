namespace TestTaskIronWaterStudio.Models
{
    public class MockProductRepository : IProductRepository
    {
        public IEnumerable<Product> AllProducts => 
            new List<Product>()
            {
                new Product { ProductId = 1, Name = "Pie", Description="It's Pie", Price=10.00M },
                new Product { ProductId = 2, Name = "Pizza", Description="It's Pizza", Price=10.00M },
                new Product { ProductId = 3, Name = "Rolls", Description="It's Rolls", Price=10.00M }
            };

        public Product? GetProductById(int productId) =>
            AllProducts.FirstOrDefault(p => p.ProductId == productId);
    }
}
