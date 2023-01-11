using AutoMapper;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            // Users
            CreateMap<ImportUserDto, User>();

            CreateMap<User, UserSoldProductsDto>()
                .ForMember(dest => dest.SoldProducts, opt => opt
                    .MapFrom(src => src.ProductsSold
                        .Where(ps => ps.BuyerId.HasValue)));

            // Products
            CreateMap<ImportProductDto, Product>();

            CreateMap<Product, ProductPriceRangeDto>()
                .ForMember(dest => dest.BuyerFullName, opt => opt
                    .MapFrom(src => $"{src.Buyer.FirstName} {src.Buyer.LastName}"));

            CreateMap<Product, SoldProductDto>();

            // Categories
            CreateMap<ImportCategoryDto, Category>();

            CreateMap<Category, CategoryProductsDto>()
                .ForMember(dest => dest.ProductsCount, opt => opt
                    .MapFrom(src => src.CategoryProducts.Count))
                .ForMember(dest => dest.AveragePrice, opt => opt
                    .MapFrom(src => src.CategoryProducts.Average(cp => cp.Product.Price)))
                .ForMember(dest => dest.TotalRevenue, opt => opt
                    .MapFrom(src => src.CategoryProducts.Sum(cp => cp.Product.Price)));

            // CategoryProducts
            CreateMap<ImportCategoryProductDto, CategoryProduct>();
        }
    }
}
