using BlazorSeverApp.Data.Dtos;
using BlazorSeverApp.Infrastructure;
using BlazorSeverApp.Services.IServices;
using static BlazorSeverApp.Infrastructure.ApplicationConstants;

namespace BlazorSeverApp.Services
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;

        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> Create(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiTypes.POST,
                Url = ApplicationConstants.CouponApiUrl,
                Data = couponDto
            });
        }

        public async Task<ResponseDto?> Delete(int id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiTypes.DELETE,
                Url = ApplicationConstants.CouponApiUrl + id
            });
        }

        public async Task<ResponseDto?> GetAll()
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiTypes.GET,
                Url = ApplicationConstants.CouponApiUrl
            });
        }

        public async Task<ResponseDto?> GetByCode(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiTypes.GET,
                Url = ApplicationConstants.CouponApiUrl + "GetByCode/" + couponCode
            });
        }

        public async Task<ResponseDto?> GetById(int id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiTypes.GET,
                Url = ApplicationConstants.CouponApiUrl + id
            });
        }

        public async Task<ResponseDto?> Update(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiTypes.PUT,
                Url = ApplicationConstants.CouponApiUrl,
                Data = couponDto
            });
        }
    }
}
