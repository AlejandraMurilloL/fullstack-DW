using AutoMapper;
using DW.Domain.DTOs;
using DW.Domain.Entities;

namespace DW.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<CustomerDto, Customer>();
            CreateMap<Customer, CustomerDto>()
                .ForMember(x => x.DisplayExpression, x => x.MapFrom(src => src.FirstName + " " + src.LastName));
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>()
                .ForMember(x => x.DisplayExpression, x => x.MapFrom(src => src.Name + " - " + src.Price));
            CreateMap<Invoice, InvoiceDto>()
                .ForMember(x => x.Num, x => x.MapFrom(src => src.Num.ToString().PadLeft(6, '0')));
            CreateMap<InvoiceDto, Invoice>();
            CreateMap<InvoiceDetailDto, InvoiceDetail>().ReverseMap();
        }
    }
}
