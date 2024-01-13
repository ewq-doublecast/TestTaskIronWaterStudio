using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TestTaskIronWaterStudio.Models
{
    public class TestTaskDbContext : IdentityDbContext
    {
        public TestTaskDbContext(DbContextOptions<TestTaskDbContext> options) : base(options) { }
        
        public DbSet<Product> Products { get; set; }
    }
}
