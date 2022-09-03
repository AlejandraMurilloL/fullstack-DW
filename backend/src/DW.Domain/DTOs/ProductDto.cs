namespace DW.Domain.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public CategoryDto Category { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        public string DisplayExpression { get; set; }
    }
}
