using AutoMapper;
using ProductApi.Data.Dtos;
using ProductApi.Data.Models;

namespace ProductApi.Infrastructure
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMapps()
        {
            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<Products, ProductDto>().ReverseMap();
            });
            return mapperConfiguration;
        }
    }
}
