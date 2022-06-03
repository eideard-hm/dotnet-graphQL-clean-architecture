namespace Inventory.Domain.Entities
{
    public class InvoiceDetail
    {
        public int ProductId { get; set; }
        public int InvoiceId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        // relationship with Product and Invoice
        public Product Product { get; set; }
        public Invoice Invoice { get; set; }
    }
}
