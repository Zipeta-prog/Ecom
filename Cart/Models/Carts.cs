namespace Cart.Models
{
    public class Carts
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string CouponCode { get; set; } = string.Empty;
        public double Discount { get; set; }
        public double CartTotal { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public decimal Subtotal { get; set; }
        public Guid ProductId { get; internal set; }
    }
}
