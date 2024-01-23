namespace CartApi.Data.Dtos
{
    public class CouponDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public double Discount { get; set; }
        public int MinAmount { get; set; }
    }
}
