using Inventory.Domain.Entities;
using Inventory.Domain.Interfaces;
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

        public Task<Category> Add(Category category)
        {
            _db.Categories.Add(category);
            return Task.FromResult(category);
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
            var editCategory = await this.GetCategoryByIdAsync(category.CategoryId);
            if (editCategory != null)
            {
                editCategory.Name = category.Name;
                editCategory.Description = category.Description;
                editCategory.Products = category.Products;

                await Task.FromResult(_db.Entry(editCategory).State = EntityState.Modified);
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

        private async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _db.Categories.FindAsync(id);
        }
    }
}
