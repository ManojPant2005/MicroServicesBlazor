using CartApi.Data.Dtos;
using CartApi.Infrastructure;
using Newtonsoft.Json;

namespace CartApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var client = _httpClientFactory.CreateClient("Products");
            var response = await client.GetAsync($"");
            var apiContent = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
            if (resp!.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(Convert.ToString(resp!.Result));
            }
            return new List<ProductDto>();
        }
    }
}
