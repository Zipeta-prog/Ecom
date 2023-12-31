namespace Products.Model.Dtos
{
    public class AddProductDto
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; } = 0;
    }
}
