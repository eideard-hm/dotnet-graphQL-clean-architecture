using Inventory.Application.Interfaces;
using Inventory.Domain.Entities;
using Inventory.Domain.Interfaces.Repository;

namespace Inventory.Application.Services
{
    public class CategoryService : IBaseService<Category, int>
    {
        private readonly IBaseRepository<Category, int> _repository;

        public CategoryService(IBaseRepository<Category, int> repository)
        {
            _repository = repository;
        }

        public async Task<Category> Add(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(string.Format("La categoria es requerida!"));
            }

            var newCategory = _repository.Add(category);
            await _repository.SaveAllChangesAsync();
            return await newCategory;
        }

        public async Task Delete(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException(string.Format("El id de la categoria es requerido!"));
            }

            var deletedCategory = await GetByIdAsync(id);
            if (deletedCategory == null)
            {
                throw new InvalidOperationException(string.Format("Esta tratando de eliminar una categoria que no existe!"));
            }

            await _repository.Delete(id);
            await _repository.SaveAllChangesAsync();
        }

        public async Task Edit(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(string.Format("La categoria es requerida!"));
            }
            var updatedCategory = await GetByIdAsync(category.CategoryId);
            if (updatedCategory == null)
            {
                throw new InvalidOperationException(string.Format($"La categoria ${category.Name ?? category.CategoryId.ToString()} no existe !"));
            }
            await _repository.Edit(category);
            await _repository.SaveAllChangesAsync();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
