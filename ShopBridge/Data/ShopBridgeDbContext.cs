using Microsoft.EntityFrameworkCore;
using ShopBridge.Models;

namespace ShopBridge.Data
{
    public class ShopBridgeDbContext:DbContext
    {
        public ShopBridgeDbContext(DbContextOptions<ShopBridgeDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Product> Item { get; set; }
    }
}
