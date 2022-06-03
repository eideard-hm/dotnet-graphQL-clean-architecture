using Inventory.Domain.Entities;
using Inventory.Domain.Interfaces.Repository;
using Inventory.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Repository
{
    public class CategoryRepository : IBaseRepository<Category, int>
    {
        private readonly InventoryContext _db;

        public CategoryRepository(InventoryContext context)
        {
            _db = context;
        }

        public Category Add(Category category)
        {
            _db.Categories.Add(category);
            return category;
        }

        public async Task Delete(int id)
        {
            var deletedCategory = await _db.Categories.FindAsync(id);
            if (deletedCategory != null)
            {
                _db.Categories.Remove(deletedCategory);
            }
        }

        public async Task Edit(Category category)
        {
            var editCategory = await _db.Categories.FindAsync(category.CategoryId);
            if(editCategory == null)
            {
                throw new InvalidOperationException(string.Format("La categoria que esta "));
            }
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _db.Categories
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _db.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CategoryId == id);
        }

        public async Task SaveAllChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
