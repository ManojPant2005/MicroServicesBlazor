namespace BlazorSeverApp.Data.Dtos.AuthApi
{
    public class LoginResponseDto
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
    }
}
