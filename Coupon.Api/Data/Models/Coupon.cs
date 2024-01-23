using System.ComponentModel.DataAnnotations;

namespace CouponApi.Data.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public double Discount { get; set; }
        public int MinAmount { get; set; }

        //public DateTime LastUpdated { get; set; }
    }
}
