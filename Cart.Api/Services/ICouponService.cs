using CartApi.Data.Dtos;

namespace CartApi.Services
{
    public interface ICouponService
    {
        Task<CouponDto> GetByCode(string code);
    }
}
