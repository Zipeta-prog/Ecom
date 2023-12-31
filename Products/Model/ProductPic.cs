using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Model
{
    public class ProductPic
    {
        public Guid Id { get; set; }

        public string Pic { get; set; } = string.Empty;

        [ForeignKey("ProductId")]
        public Product t { get; set; } = default!;

        public Guid ProductId { get; set; }
    }
}
