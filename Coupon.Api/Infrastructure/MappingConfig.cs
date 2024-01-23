using AutoMapper;
using CouponApi.Data.Dtos;
using CouponApi.Data.Models;

namespace CouponApi.Infrastructure
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMapps()
        {
            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<Coupon, CouponDto>().ReverseMap();
            });
            return mapperConfiguration;
        }
    }
}
