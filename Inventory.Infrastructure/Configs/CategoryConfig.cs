using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.Configs
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // define primary key
            builder.HasKey(c => c.CategoryId);

            // define data types
            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(1000);

            // define relationships
            // relation with Product
            builder
                .HasMany(category => category.Products)
                .WithOne(product => product.Category);
        }
    }
}
