namespace Inventory.Domain.Interfaces
{
    public interface IEdit<TEntity>
    {
        Task Edit(TEntity entity);
    }
}
