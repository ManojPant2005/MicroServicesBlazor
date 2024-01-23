namespace CartApi.Data.Dtos
{
    public class CartDto
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? CouponCode { get; set; }
        public double Discount { get; set; }
        public double Total { get; set; }

        public List<CartDetailDto>? CartDetailDtos { get; set; } = new();
    }
}
