using BlazorSeverApp.Data.Dtos;
using BlazorSeverApp.Infrastructure;

namespace BlazorSeverApp.Services.IServices
{
    public interface IProductService
    {
        Task<ResponseDto?> GetAll();
        Task<ResponseDto?> GetById(int id);
        Task<ResponseDto?> Create(ProductDto dto);
        Task<ResponseDto?> Update(ProductDto dto);
        Task<ResponseDto?> Delete(int id);
    }
}
