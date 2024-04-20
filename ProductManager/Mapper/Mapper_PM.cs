using AutoMapper;
using ProductManager.Dto;
using ProductManager.Entity;

namespace ProductManager.Mapper
{
    public class Mapper_PM:Profile
    {
        public Mapper_PM()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category,CategoryDto>().ReverseMap();
            CreateMap<Product, GetAllProductdto>().ReverseMap();

        }
    }
}
