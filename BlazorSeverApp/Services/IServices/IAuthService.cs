using BlazorSeverApp.Data.Dtos.AuthApi;
using BlazorSeverApp.Infrastructure;

namespace BlazorSeverApp.Services.IServices
{
    public interface IAuthService
    {
        Task<ResponseDto?> Login(LoginRequestDto loginRequest);
        Task<ResponseDto?> Register(RegisterDto registerDto);
        Task<ResponseDto?> AssignToRole(RegisterDto registerDto);
    }
}
