using Inventory.Application.Interfaces;
using Inventory.Domain.Entities;
using Inventory.Domain.Interfaces.Repository;

namespace Inventory.Application.Services
{
    public class ProductService : IBaseService<Product, int>
    {
        private readonly IBaseRepository<Product, int> _repository;

        public ProductService(IBaseRepository<Product, int> repository)
        {
            _repository = repository;
        }

        public async Task<Product> Add(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(string.Format("El producto es requerido!"));
            }
            var newProduct = _repository.Add(product);
            await _repository.SaveAllChangesAsync();
            return await newProduct;
        }

        public async Task Delete(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException(string.Format("El id del producto es requerido!"));
            }

            var deletedProduct = await GetByIdAsync(id);
            if (deletedProduct == null)
            {
                throw new InvalidOperationException(string.Format("Esta tratando de eliminar un producto que no existe!"));
            }

            await _repository.Delete(id);
            await _repository.SaveAllChangesAsync();
        }

        public async Task Edit(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(string.Format("La categoria es requerida!"));
            }
            var updatedProduct = await GetByIdAsync(product.ProductId);
            if (updatedProduct == null)
            {
                throw new InvalidOperationException(string.Format($"El producto ${product.Name ?? product.ProductId.ToString()} no existe !"));
            }
            await _repository.Edit(product);
            await _repository.SaveAllChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
