using Inventory.Application.Interfaces;
using Inventory.Domain.Entities;
using Inventory.Domain.Interfaces.Repository;

namespace Inventory.Application.Services
{
    public class ClientService : IBaseService<Client, int>
    {
        private readonly IBaseRepository<Client, int> _repository;

        public ClientService(IBaseRepository<Client, int> repository)
        {
            _repository = repository;
        }

        public async Task<Client> Add(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(string.Format("El cliente es requerido!"));
            }
            var newCliente = _repository.Add(client);
            await _repository.SaveAllChangesAsync();
            return await newCliente;
        }

        public async Task Delete(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException(string.Format("El id del cliente es requerido!"));
            }

            var deletedClient = await GetByIdAsync(id);
            if (deletedClient == null)
            {
                throw new InvalidOperationException(string.Format("Esta tratando de eliminar un cliente que no existe!"));
            }

            await _repository.Delete(id);
            await _repository.SaveAllChangesAsync();
        }

        public async Task Edit(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(string.Format("La categoria es requerida!"));
            }
            var updatedClient = await GetByIdAsync(client.ClientId);
            if (updatedClient == null)
            {
                throw new InvalidOperationException(string.Format($"El cliente ${client.Name ?? client.ClientId.ToString()} no existe !"));
            }
            await _repository.Edit(client);
            await _repository.SaveAllChangesAsync();
        }

        public async Task<List<Client>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
