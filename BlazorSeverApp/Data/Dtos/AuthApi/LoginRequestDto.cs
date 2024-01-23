using System.ComponentModel.DataAnnotations;

namespace BlazorSeverApp.Data.Dtos.AuthApi
{
    public class LoginRequestDto
    {
        [Required(ErrorMessage = "{0} is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string Password { get; set; }
    }
}
