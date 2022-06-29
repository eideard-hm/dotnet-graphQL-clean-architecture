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
            if(product == null)
            {
                throw new ArgumentNullException(string.Format("El 'Producto' es requerido!"));
            }

            return await _repository.Add(product);
        }

        public async Task Delete(int id)
        {
            if(id == 0)
            {
                throw new ArgumentNullException(string.Format("Se requiere el 'Id' del Producto que desea eliminar!"));
            }
            await _repository.Delete(id);
        }

        public async Task Edit(Product product)
        {
            if(product is null)
            {
                throw new ArgumentNullException(string.Format("Se debe de enviar el 'Producto' que quiere editar!"));
            }

            await _repository.Edit(product);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }
    }
}
