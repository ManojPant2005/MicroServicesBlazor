using BlazorSeverApp.Data.Dtos;
using BlazorSeverApp.Infrastructure;
using BlazorSeverApp.Services.IServices;
using static BlazorSeverApp.Infrastructure.ApplicationConstants;

namespace BlazorSeverApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IBaseService _baseService;

        public ProductService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> Create(ProductDto dto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiTypes.POST,
                Url = ApplicationConstants.ProductApiUrl,
                Data = dto
            });
        }

        public async Task<ResponseDto?> Delete(int id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiTypes.DELETE,
                Url = ApplicationConstants.ProductApiUrl + id
            });
        }

        public async Task<ResponseDto?> GetAll()
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiTypes.GET,
                Url = ApplicationConstants.ProductApiUrl
            });
        }

        public async Task<ResponseDto?> GetById(int id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiTypes.GET,
                Url = ApplicationConstants.ProductApiUrl + id
            });
        }

        public async Task<ResponseDto?> Update(ProductDto dto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiTypes.PUT,
                Url = ApplicationConstants.ProductApiUrl,
                Data = dto
            });
        }
    }
}
