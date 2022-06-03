namespace Inventory.Domain.Entities
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        //relationship with Invoice
        public List<Invoice> Invoices { get; set; }
    }
}
