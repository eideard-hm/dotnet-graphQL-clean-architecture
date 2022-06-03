namespace Inventory.Domain.Entities
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public DateTime Date { get; set; }

        //relationshipt with InvoiceDetail
        public List<InvoiceDetail> InvoiceDetails { get; set; }
        // relationship with Client
        public Client Client { get; set; }
    }
}
