using System.ComponentModel.DataAnnotations.Schema;

namespace CartApi.Data.Models
{
    public class Carts
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? CouponCode { get; set; }
        [NotMapped]
        public double Discount { get; set; }
        [NotMapped]
        public double Total { get; set; }
    }
}
