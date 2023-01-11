using AutoMapper;
using ProductShop.DTOs;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            // Products
            CreateMap<Product, ProductPriceRangeDto>()
                .ForMember(dest => dest.SellerFullName, opt => opt
                    .MapFrom(src => $"{src.Seller.FirstName} {src.Seller.LastName}"));

            CreateMap<Product, SoldProductDto>()
                .ForMember(dest => dest.BuyerFirstName, opt => opt
                    .MapFrom(src => src.Buyer.FirstName))
                .ForMember(dest => dest.BuyerLastName, opt => opt
                    .MapFrom(src => src.Buyer.LastName));

            // Users
            CreateMap<User, UserSoldProductsDto>()
                .ForMember(dest => dest.SoldProducts, opt => opt
                    .MapFrom(src => src.ProductsSold
                        .Where(ps => ps.BuyerId.HasValue)));

            // Categories
            CreateMap<Category, CategoryProductsDto>()
                .ForMember(dest => dest.ProductsCount, opt => opt
                    .MapFrom(src => src.CategoryProducts.Count))
                .ForMember(dest => dest.AveragePrice, opt => opt
                    .MapFrom(src => src.CategoryProducts
                        .Average(cp => cp.Product.Price).ToString("F2")))
                .ForMember(dest => dest.TotalRevenue, opt => opt
                    .MapFrom(src => src.CategoryProducts
                        .Sum(cp => cp.Product.Price).ToString("F2")));
        }
    }
}
