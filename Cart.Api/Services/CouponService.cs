
using CartApi.Data.Dtos;
using CartApi.Infrastructure;
using Newtonsoft.Json;

namespace CartApi.Services
{
    public class CouponService : ICouponService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CouponService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<CouponDto> GetByCode(string code)
        {
            var client = _httpClientFactory.CreateClient("Coupons");
            var response = await client.GetAsync($"GetByCode/{code}");
            var apiContent = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
            if (resp is not null && resp.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(resp!.Result));
            }
            return new CouponDto();
        }

    }
}
