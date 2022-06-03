using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.Configs
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // define primary key
            builder.HasKey(p => p.ProductId);

            // define default values and data types
            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .Property(p => p.Price)
                .IsRequired()
                .HasPrecision(18, 3);

            builder
                .Property(p => p.Stock)
                .IsRequired()
                .HasPrecision(18, 2)
                .HasDefaultValue(0);

            // define relationships
            // relation with Category / Muchos Product  -> 1 Category
            builder
                .HasOne(product => product.Category)
                .WithMany(category => category.Products);
            // relation with InvoiceDetail / 1 Product -> Muchas InvoiceDetail
            builder
                .HasMany(product => product.InvoiceDetails)
                .WithOne(detail => detail.Product);
        }
    }
}
