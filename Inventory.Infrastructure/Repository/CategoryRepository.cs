using Inventory.Domain.Entities;
using Inventory.Domain.Interfaces.Repository;
using Inventory.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Repository
{
    public class CategoryRepository : IBaseRepository<Category, int>
    {
        private readonly InventoryContext _db;

        public CategoryRepository(InventoryContext db)
        {
            _db = db;
        }

        public async Task<Category> Add(Category category)
        {
            _db.Categories.Add(category);
            await SaveChangesAsync();
            return category;
        }

        public async Task Delete(int id)
        {
           var categoryDeleted = await GetByIdWithTracking(id);
            if(categoryDeleted != null)
            {
                _db.Categories.Remove(categoryDeleted);
                await SaveChangesAsync();
            }
        }

        public async Task Edit(Category category)
        {
            _db.Entry(category).State = EntityState.Modified;
            await SaveChangesAsync();
        }

        public Task<List<Category>> GetAllAsync()
        {
            return _db.Categories
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _db.Categories
                                       .AsNoTracking()
                                       .FirstOrDefaultAsync(c => c.CategoryId == id);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }

        private async Task<Category> GetByIdWithTracking(int id)
        {
            return await _db.Categories.FindAsync(id);
        }
    }
}
