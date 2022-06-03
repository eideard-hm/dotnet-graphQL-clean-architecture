namespace Inventory.Domain.Interfaces
{
    public interface IReadable<TEntity, TEntityId>
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TEntityId id);
    }
}
