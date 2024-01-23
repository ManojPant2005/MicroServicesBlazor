using BlazorSeverApp.Data.Dtos;
using BlazorSeverApp.Infrastructure;
using BlazorSeverApp.Services.IServices;
using static BlazorSeverApp.Infrastructure.ApplicationConstants;

namespace BlazorSeverApp.Services
{
    public class CartService : ICartService
    {
        private readonly IBaseService _baseService;

        public CartService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> ApplyCoupon(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiTypes.POST,
                Url = ApplicationConstants.CartApiUrl + "ApplyCoupon",
                Data = cartDto
            });
        }

        public async Task<ResponseDto?> CreateEdit(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiTypes.POST,
                Url = ApplicationConstants.CartApiUrl + "CreateEdit",
                Data = cartDto
            });
        }

        public async Task<ResponseDto?> GetCartByUserId(string userId)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiTypes.GET,
                Url = ApplicationConstants.CartApiUrl + $"GetCart/{userId}",
            });
        }

        public async Task<ResponseDto?> Remove(int cartDetailId)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiTypes.POST,
                Url = ApplicationConstants.CartApiUrl + $"Remove",
                Data = cartDetailId
            });
        }

        public async Task<ResponseDto?> RemoveCoupon(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiTypes.POST,
                Url = ApplicationConstants.CartApiUrl + "RemoveCoupon",
                Data = cartDto
            });
        }
    }
}
