namespace Inventory.Domain.Interfaces.Repository
{
    public interface IInvoiceRepository<TEntity, TEntityId> :
        IAdd<TEntity>, IReadable<TEntity, TEntityId>
    {
        void Anular(TEntityId id);
    }
}
