using Inventory.Domain.Entities;
using Inventory.Domain.Interfaces.Repository;
using Inventory.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Repository
{
    public class ProductRepository : IBaseRepository<Product, int>
    {
        private readonly InventoryContext _db;

        public ProductRepository(InventoryContext db)
        {
            _db = db;
        }

        public async Task<Product> Add(Product product)
        {
            _db.Products.Add(product);
            await SaveChangesAsync();
            return product;
        }

        public async Task Delete(int id)
        {
            var productDeleted = await GetByIdWithTrackingAsync(id);
            if(productDeleted != null)
            {
                _db.Products.Remove(productDeleted);
                await SaveChangesAsync();
            }
        }

        public async Task Edit(Product product)
        {
            var productEdit = await GetByIdWithTrackingAsync(product.ProductId);
            if(productEdit != null)
            {
                _db.Entry(product).State = EntityState.Modified;
                await SaveChangesAsync();
            }
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _db.Products
                               .AsNoTracking()
                               .ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _db.Products
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(prod => prod.ProductId == id);
        }

        private async Task<Product> GetByIdWithTrackingAsync(int id)
        {
            return await _db.Products.FindAsync(id);
        }

        private async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
