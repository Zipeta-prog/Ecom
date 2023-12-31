namespace Orders.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string CouponCode { get; set; } = string.Empty;
        public double Discount { get; set; }
        public double OrderTotal { get; set; }
        public decimal Subtotal { get; set; }
        public Guid ProductId { get; internal set; }
        public string? StripeSessionId { get; set; }
        public string Status { get; set; } = "Pending";
        public string PaymentIntent { get; set; } = string.Empty;
    }
}
