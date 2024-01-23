using BlazorSeverApp.Data.Dtos;
using BlazorSeverApp.Infrastructure;

namespace BlazorSeverApp.Services.IServices
{
    public interface ICartService
    {
        Task<ResponseDto?> GetCartByUserId(string userId);
        Task<ResponseDto?> CreateEdit(CartDto cartDto);
        Task<ResponseDto?> Remove(int cartDetailId);
        Task<ResponseDto?> ApplyCoupon(CartDto cartDto);
        Task<ResponseDto?> RemoveCoupon(CartDto cartDto);
    }
}
