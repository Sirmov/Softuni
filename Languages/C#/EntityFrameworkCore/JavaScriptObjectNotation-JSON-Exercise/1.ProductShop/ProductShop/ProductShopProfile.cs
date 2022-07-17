using AutoMapper;
using ProductShop.DTOs;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            // Products
            CreateMap<Product, ProductPriceRangeDto>()
                .ForMember(dest => dest.SellerFullName,
                    opt => opt.MapFrom(src => $"{src.Seller.FirstName} {src.Seller.LastName}"));
        }
    }
}
