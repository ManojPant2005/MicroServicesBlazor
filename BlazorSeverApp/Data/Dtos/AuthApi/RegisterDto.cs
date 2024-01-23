using System.ComponentModel.DataAnnotations;

namespace BlazorSeverApp.Data.Dtos.AuthApi
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string? RoleName { get; set; }
    }
}
