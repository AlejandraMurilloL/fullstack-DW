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
            CreateMap<CustomerDto, Customer>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<InvoiceDto, Invoice>().ReverseMap();
            CreateMap<InvoiceDetailDto, InvoiceDetail>().ReverseMap();
        }
    }
}
