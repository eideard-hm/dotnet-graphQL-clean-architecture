namespace Inventory.Domain.Interfaces.Repository
{
    public interface IInvoiceDetailRepository<TEntity>:
        IAdd<TEntity>, ITransacction
    {
    }
}
