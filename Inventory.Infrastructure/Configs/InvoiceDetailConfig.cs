using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.Configs
{
    internal class InvoiceDetailConfig : IEntityTypeConfiguration<InvoiceDetail>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
        {
            // define composed primary key
            builder.HasKey(id => new { id.ProductId, id.InvoiceId });

            // define data types
            builder
                .Property(id => id.Price)
                .IsRequired()
                .HasPrecision(18, 3);

            builder
                .Property(id => id.Quantity)
                .HasPrecision(18, 2)
                .IsRequired();

            // define relationships
            // relation with Product
            builder
                .HasOne(detalle => detalle.Product)
                .WithMany(product => product.InvoiceDetails);

            // relation with Invoice
            builder
                .HasOne(detail => detail.Invoice)
                .WithMany(invoice => invoice.InvoiceDetails);
        }
    }
}
