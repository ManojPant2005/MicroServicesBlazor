using AutoMapper;
using CouponApi.Data;
using CouponApi.Data.Dtos;
using CouponApi.Data.Models;
using CouponApi.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CouponApi.Controllers
{
    [Route("api/coupons")]
    [ApiController]
    [Authorize]
    public class CouponsController : ControllerBase
    {
        private ApplicationDbContext _db { get; set; }
        private readonly ILogger<CouponsController> _logger;
        private ResponseDto _response;
        private IMapper _mapper;

        public CouponsController(ApplicationDbContext db, ILogger<CouponsController> logger, IMapper mapper)
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
                var result = await _db.Coupons.ToListAsync();
                _response.Result = _mapper.Map<List<CouponDto>>(result);
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
                var result = await _db.Coupons.FirstAsync(x => x.Id == id);
                _response.Result = _mapper.Map<CouponDto>(result);
            }
            catch (Exception e)
            {
                _response.IsSuccessful = false;
                _response.Message = e.Message;
            }
            return _response;
        }
        [HttpGet("GetByCode/{code}")]
        public async Task<ResponseDto> Get(string code)
        {
            try
            {
                var result = await _db.Coupons.FirstAsync(x => x.Code.ToLower() == code.ToLower());
                _response.Result = _mapper.Map<CouponDto>(result);
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
        public async Task<ResponseDto> Post([FromBody] CouponDto dto)
        {
            try
            {
                var model = _mapper.Map<Coupon>(dto);
                await _db.Coupons.AddAsync(model);
                await _db.SaveChangesAsync();

                _response.Result = _mapper.Map<CouponDto>(model);
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
        public async Task<ResponseDto> Put([FromBody] CouponDto dto)
        {
            try
            {
                var model = _mapper.Map<Coupon>(dto);
                _db.Coupons.Update(model);
                await _db.SaveChangesAsync();

                _response.Result = _mapper.Map<CouponDto>(model);
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
                var model = await _db.Coupons.FirstAsync(x => x.Id == id);
                _db.Coupons.Remove(model);
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
