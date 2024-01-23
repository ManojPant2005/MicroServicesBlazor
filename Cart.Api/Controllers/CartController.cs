using AutoMapper;
using CartApi.Data;
using CartApi.Data.Dtos;
using CartApi.Data.Models;
using CartApi.Infrastructure;
using CartApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CartApi.Controllers
{
    [Route("api/carts")]
    [ApiController]
    [Authorize]
    public class CartsController : ControllerBase
    {
        private ApplicationDbContext _db { get; set; }
        private readonly ILogger<CartsController> _logger;
        private ResponseDto _response;
        private IMapper _mapper;
        private readonly IProductService _productService;
        private readonly ICouponService _couponService;

        public CartsController(ApplicationDbContext db, ILogger<CartsController> logger, IMapper mapper, IProductService productService, ICouponService couponService)
        {
            _db = db;
            _logger = logger;
            _response = new();
            _mapper = mapper;
            _productService = productService;
            _couponService = couponService;
        }

        [HttpGet("GetCart/{userId}")]
        public async Task<ResponseDto> GetCart(string userId)
        {
            try
            {
                var cartInDb = await _db.Cart.FirstAsync(x => x.UserId == userId);
                var cartDetailsInDb = await _db.CartDetails.Where(x => x.CartId == cartInDb.Id).ToListAsync();

                var productDtos = await _productService.GetAll();

                var cartDto = _mapper.Map<CartDto>(cartInDb);
                cartDto.CartDetailDtos = _mapper.Map<List<CartDetailDto>>(cartDetailsInDb);

                foreach (var cartDetailDto in cartDto.CartDetailDtos)
                {
                    cartDetailDto.Product = productDtos.FirstOrDefault(x => x.Id == cartDetailDto.ProductId);
                    cartDto.Total += cartDetailDto.Count * cartDetailDto.Product!.Price;
                }
                //cartDto.CartDetailDtos.Select(x => x.Product = productDtos.FirstOrDefault(y => y.Id == x.ProductId));
                //cartDto.Total = cartDetails.Sum(x => x.Count * x.Product.Price);

                if (string.IsNullOrEmpty(cartDto.CouponCode) == false)
                {
                    var coupon = await _couponService.GetByCode(cartDto.CouponCode);
                    if (coupon is not null && cartDto.Total > coupon.MinAmount)
                    {
                        cartDto.Total -= coupon.Discount;
                        cartDto.Discount = coupon.Discount;
                    }
                }

                _response.Result = cartDto;
            }
            catch (Exception e)
            {
                _response.IsSuccessful = false;
                _response.Message = e.Message;
            }
            return _response;
        }

        [HttpPost("ApplyCoupon")]
        public async Task<ResponseDto> ApplyCoupon([FromBody] CartDto cartDto)
        {
            try
            {
                var cartFromDb = await _db.Cart.FirstAsync(x => x.Id == cartDto.Id);
                cartFromDb.CouponCode = cartDto.CouponCode;
                _db.Cart.Update(cartFromDb);
                await _db.SaveChangesAsync();
                _response.Result = true;
            }
            catch (Exception e)
            {
                _response.IsSuccessful = false;
                _response.Message = e.Message;
            }
            return _response;
        }

        [HttpPost("RemoveCoupon")]
        public async Task<ResponseDto> RemoveCoupon([FromBody] CartDto cartDto)
        {
            try
            {
                var cartFromDb = await _db.Cart.FirstAsync(x => x.Id == cartDto.Id);
                cartFromDb.CouponCode = string.Empty;
                _db.Cart.Update(cartFromDb);
                await _db.SaveChangesAsync();
                _response.Result = true;
            }
            catch (Exception e)
            {
                _response.IsSuccessful = false;
                _response.Message = e.Message;
            }
            return _response;
        }

        [HttpPost("CreateEdit")]
        [Authorize(Roles = "Admins")]
        public async Task<ResponseDto> CreateEdit([FromBody] CartDto cartDto)
        {
            try
            {
                var cartInDb = _db.Cart.AsNoTracking().FirstOrDefault(x => x.UserId == cartDto.UserId);
                if (cartInDb is null)
                {
                    //create cart
                    var cart = _mapper.Map<Carts>(cartDto);
                    _db.Cart.Add(cart);
                    await _db.SaveChangesAsync();

                    cartDto.Id = cart.Id;
                    cartDto.CartDetailDtos!.First().CartId = cart.Id;

                    await _db.CartDetails.AddAsync(_mapper.Map<CartDetail>(cartDto.CartDetailDtos!.First()));
                    await _db.SaveChangesAsync();
                }
                else
                {
                    //edit cart
                    var cartDetailInDb = await _db.CartDetails.AsNoTracking().FirstOrDefaultAsync(x =>
                    x.CartId == cartInDb.Id &&
                    x.ProductId == cartDto.CartDetailDtos!.First().ProductId);

                    if (cartDetailInDb is null)
                    {
                        //create detail
                        cartDto.CartDetailDtos!.First().CartId = cartInDb.Id;

                        await _db.CartDetails.AddAsync(_mapper.Map<CartDetail>(cartDto.CartDetailDtos!.First()));
                        await _db.SaveChangesAsync();
                    }
                    else
                    {
                        //edit detail
                        cartDto.CartDetailDtos!.First().CartId = cartDetailInDb.CartId;
                        cartDto.CartDetailDtos!.First().Id = cartDetailInDb.Id;
                        cartDto.CartDetailDtos!.First().Count += cartDetailInDb.Count;

                        _db.CartDetails.Update(_mapper.Map<CartDetail>(cartDto.CartDetailDtos!.First()));
                        await _db.SaveChangesAsync();
                    }
                }

                _response.Result = cartDto;
            }
            catch (Exception e)
            {
                _response.IsSuccessful = false;
                _response.Message = e.Message;
            }
            return _response;
        }

        [HttpPost("Remove")]
        [Authorize(Roles = "Admins")]
        public async Task<ResponseDto> Remove([FromBody] int cartDetailId)
        {
            try
            {
                var cartDetailInDb = await _db.CartDetails.AsNoTracking().FirstAsync(x => x.Id == cartDetailId);
                var count = _db.CartDetails.Where(x => x.CartId == cartDetailInDb.Id).Count();
                _db.CartDetails.Remove(cartDetailInDb);
                if (count == 1)
                {
                    var cartInDb = await _db.Cart.FirstOrDefaultAsync(x => x.Id == cartDetailInDb.CartId);
                    _db.Cart.Remove(cartInDb);
                }
                await _db.SaveChangesAsync();

                _response.Result = true;
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
