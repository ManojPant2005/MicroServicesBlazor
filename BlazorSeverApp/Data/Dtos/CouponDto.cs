using System.ComponentModel.DataAnnotations;

namespace BlazorSeverApp.Data.Dtos
{
    public class CouponDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(5, MinimumLength = 5,
        ErrorMessage = "{0} should be minimum {2} characters and a maximum of {1} characters")]
        public string Code { get; set; }

        [Range(0, 1000,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public double Discount { get; set; }

        [Range(0, 1000,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int MinAmount { get; set; }
    }
}
