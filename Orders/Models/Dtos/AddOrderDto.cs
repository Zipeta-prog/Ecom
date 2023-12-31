namespace Orders.Models.Dtos
{
    public class AddOrderDto
    {
        public Guid UserId { get; set; }
        public double OrderTotal { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
    }
}
