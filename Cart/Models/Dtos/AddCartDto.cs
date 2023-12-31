namespace Cart.Models.Dtos
{
    public class AddCartDto
    {
        public Guid UserId { get; set; }
        public double CartTotal { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
    }
}
