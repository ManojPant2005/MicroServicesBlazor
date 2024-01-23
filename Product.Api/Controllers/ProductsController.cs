using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Data.Dtos;
using ProductApi.Data.Models;
using ProductApi.Infrastructure;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ApplicationDbContext _db { get; set; }
        private readonly ILogger<ProductsController> _logger;
        private ResponseDto _response;
        private IMapper _mapper;

        public ProductsController(ApplicationDbContext db, ILogger<ProductsController> logger, IMapper mapper)
        {
            _db = db;
            _logger = logger;
            _response = new();
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            try
            {
                var result = await _db.Product.ToListAsync();
                _response.Result = _mapper.Map<List<ProductDto>>(result);
            }
            catch (Exception e)
            {
                _response.IsSuccessful = false;
                _response.Message = e.Message;
            }
            return _response;
        }
        [HttpGet("{id:int}")]
        public async Task<ResponseDto> Get(int id)
        {
            try
            {
                var result = await _db.Product.FirstAsync(x => x.Id == id);
                _response.Result = _mapper.Map<ProductDto>(result);
            }
            catch (Exception e)
            {
                _response.IsSuccessful = false;
                _response.Message = e.Message;
            }
            return _response;
        }

        [HttpPost]
        [Authorize(Roles = "Admins")]
        public async Task<ResponseDto> Post([FromBody] ProductDto dto)
        {
            try
            {
                var model = _mapper.Map<Products>(dto);
                await _db.Product.AddAsync(model);
                await _db.SaveChangesAsync();

                _response.Result = _mapper.Map<ProductDto>(model);
            }
            catch (Exception e)
            {
                _response.IsSuccessful = false;
                _response.Message = e.Message;
            }
            return _response;
        }

        [HttpPut]
        [Authorize(Roles = "Admins")]
        public async Task<ResponseDto> Put([FromBody] ProductDto dto)
        {
            try
            {
                var model = _mapper.Map<Products>(dto);
                _db.Product.Update(model);
                await _db.SaveChangesAsync();

                _response.Result = _mapper.Map<ProductDto>(model);
            }
            catch (Exception e)
            {
                _response.IsSuccessful = false;
                _response.Message = e.Message;
            }
            return _response;
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admins")]
        public async Task<ResponseDto> Delete(int id)
        {
            try
            {
                var model = await _db.Product.FirstAsync(x => x.Id == id);
                _db.Product.Remove(model);
                await _db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _response.IsSuccessful = false;
                _response.Message = e.Message;
            }
            return _response;
        }
    }
}
