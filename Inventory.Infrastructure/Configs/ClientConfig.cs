using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.Configs
{
    public class ClientConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            // define primary key
            builder.HasKey(c => c.ClientId);

            // define data types
            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder
                .Property(c => c.Phone)
                .IsRequired()
                .HasMaxLength(10);

            // define relationships
            // relation with Invoice
            builder
                .HasMany(client => client.Invoices)
                .WithOne(invoice => invoice.Client);
        }
    }
}
