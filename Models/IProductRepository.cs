namespace TestTaskIronWaterStudio.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> AllProducts { get; }
        Product? GetProductById(int productId);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
    }
}
