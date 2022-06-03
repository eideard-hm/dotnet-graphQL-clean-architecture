namespace Inventory.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Stock { get; set; }

        // relationship with InvoiceDetail
        public List<InvoiceDetail> InvoiceDetails { get; set; }
        // relationship with Category
        public Category Category { get; set; }
    }
}
