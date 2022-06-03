using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.Configs
{
    public class InvoiceConfig : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            // define primary key
            builder.HasKey(i => i.InvoiceId);

            // define default values and data types
            builder
                .Property(i => i.Date)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            // define relationships
            // relation with InvoiceDetail
            builder
                .HasMany(invoice => invoice.InvoiceDetails)
                .WithOne(detail => detail.Invoice);

            // relation with Client
            builder
                .HasOne(invoice => invoice.Client)
                .WithMany(client => client.Invoices);
        }
    }
}
