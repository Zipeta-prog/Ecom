namespace Coupon.Models
{
    public class Coupons
    {
        public Guid Id { get; set; }
        public string CouponCode { get; set; } = String.Empty;
        public int CouponAmount { get; set; }
        public int CouponMinAmount { get; set; }
    }
}
