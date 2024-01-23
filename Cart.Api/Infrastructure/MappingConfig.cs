using AutoMapper;
using CartApi.Data.Dtos;
using CartApi.Data.Models;

namespace CartApi.Infrastructure
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMapps()
        {
            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<Carts, CartDto>().ReverseMap();
                config.CreateMap<CartDetail, CartDetailDto>().ReverseMap();
            });
            return mapperConfiguration;
        }
    }
}
