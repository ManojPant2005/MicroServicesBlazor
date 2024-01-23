using CartApi.Data.Dtos;

namespace CartApi.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAll();
    }
}
