namespace Loja.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public string Image { get; set; } = string.Empty;
        public Category? Category { get; set; }
    }
}
