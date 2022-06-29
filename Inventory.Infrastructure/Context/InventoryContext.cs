using Inventory.Domain.Entities;
using Inventory.Infrastructure.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Path = System.IO.Path;

namespace Inventory.Infrastructure.Context
{
    public class InventoryContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = GetAppSettingsConfig();
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // add custom configuration
            builder.ApplyConfiguration(new ClientConfig());
            builder.ApplyConfiguration(new CategoryConfig());
            builder.ApplyConfiguration(new ProductConfig());
            builder.ApplyConfiguration(new InvoiceConfig());
            builder.ApplyConfiguration(new InvoiceDetailConfig());
        }

        private static string GetAppSettingsConfig()
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
            return connectionString;
        }
    }
}
