using Microsoft.EntityFrameworkCore;

namespace TestTaskIronWaterStudio.Models
{
    public class TestTaskDbContext : DbContext
    {
        public TestTaskDbContext(DbContextOptions<TestTaskDbContext> options) : base(options) { }
        
        public DbSet<Product> Products { get; set; }
    }
}
