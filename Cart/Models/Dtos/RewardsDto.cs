namespace Cart.Models.Dtos
{
    public class RewardsDto
    {
        public Guid CartId { get; set; }

        public double CartTotal { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
