using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using AutoMapper;
using CarDealer.DTO;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            // Cars
            CreateMap<CarImportDto, Car>();

            CreateMap<Car, ToyotaCarDto>();

            CreateMap<Car, CarDto>();

            // Customers
            CreateMap<Customer, OrderedCustomerDto>()
                .ForMember(dest => dest.FormattedBirthDate, opt => opt
                    .MapFrom(src => src.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)));

            CreateMap<Customer, CustomerSalesDto>()
                .ForMember(dest => dest.FullName, opt => opt
                    .MapFrom(src => src.Name))
                .ForMember(dest => dest.BoughtCars, opt => opt
                    .MapFrom(src => src.Sales.Count))
                .ForMember(dest => dest.SpentMoney, opt => opt
                    .MapFrom(src => src.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))));

            // Suppliers
            CreateMap<Supplier, LocalSuppliersDto>()
                .ForMember(dest => dest.PartsCount, opt => opt
                    .MapFrom(src => src.Parts.Count));

            // Parts
            CreateMap<Part, CarPartDto>()
                .ForMember(dest => dest.Price, opt => opt
                    .MapFrom(src => src.Price.ToString("F2")));

            // Sales
            CreateMap<Sale, SaleDto>()
                .ForMember(dest => dest.CustomerName, opt => opt
                    .MapFrom(src => src.Customer.Name))
                .ForMember(dest => dest.Price, opt => opt
                    .MapFrom(src => src.Car.PartCars.Sum(pc => pc.Part.Price).ToString()))
                .ForMember(dest => dest.Discount, opt => opt
                    .MapFrom(src => src.Discount.ToString("F2")))
                .ForMember(dest => dest.PriceWithDiscount, opt => opt
                    .MapFrom(src => (src.Car.PartCars.Sum(pc => pc.Part.Price) - 
                       src.Car.PartCars.Sum(pc => pc.Part.Price) * src.Discount / 100).ToString("F2")));
        }
    }
}
