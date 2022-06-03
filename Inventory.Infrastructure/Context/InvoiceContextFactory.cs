using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Path = System.IO.Path;

namespace Inventory.Infrastructure.Context
{
    public class InvoiceContextFactory : IDesignTimeDbContextFactory<InventoryContext>
    {
        public InventoryContext CreateDbContext(string[] args)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "../Inventory.RestApi");
            // Build config
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("InvoiceConnection");
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Could not find connection string named 'InvoiceConnection'");
            }

            var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new InventoryContext(optionsBuilder.Options);
        }
    }
}
