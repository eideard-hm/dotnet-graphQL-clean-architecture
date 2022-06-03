namespace Inventory.Domain.Interfaces.Repository
{
    public interface ITransacction
    {
        Task SaveAllChangesAsync();
    }
}
