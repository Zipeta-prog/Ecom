using AutoMapper;
using Products.Model;
using Products.Model.Dtos;

namespace Products.Profiles
{
    public class ProductProfiles:Profile
    {
        public ProductProfiles()
        {
            CreateMap<AddProductDto, Product>().ReverseMap();
            CreateMap<AddProductPicDto, ProductPic>().ReverseMap();
        }
    }
}
