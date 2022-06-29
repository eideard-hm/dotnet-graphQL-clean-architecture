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
            if (category is null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            return await _repository.Add(category);
        }

        public async Task Delete(int id)
        {
            if (id == 0)
            {
                throw new NullReferenceException(string.Format("Debe de ingresar in 'ID' válido!"));
            }

            await _repository.Delete(id);
        }

        public async Task Edit(Category category)
        {
            if (category is null)
            {
                throw new ArgumentNullException(string.Format("La 'Categoría a actualizar es requerida!'"));
            }

            var categoryUpdated = await _repository.GetByIdAsync(category.CategoryId);
            if (categoryUpdated is null)
            {
                throw new NullReferenceException(string.Format("Esta intentando actualizar una categoría que no existe!"));
            }

            await _repository.Edit(category);
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
