namespace Inventory.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // relationship with Product
        public List<Product> Products { get; set; }
    }
}
