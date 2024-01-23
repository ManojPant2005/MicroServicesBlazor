using CartApi.Infrastructure;

namespace BlazorSeverApp.Infrastructure
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true);
    }
}
