using AuthApi.Data;

namespace AuthApi.Services.IServices
{
    public interface IAuthService
    {
        Task<string> Register(RegisterDto registerDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<bool> AssignToRole(string userName, string roleName);
    }
}
